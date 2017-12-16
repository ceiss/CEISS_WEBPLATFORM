using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace PlataformaCeiss.Services
{
    public class UserCredentials
    {
        public byte[] Salt { get; set; }
        public string Password { get; set; }
    }
    public class SS_SHA
    {
        public string[] Peppers = { "qwertyui", "htgrfds", "djfkjwnj", "ojw", "iwj4hf", "34u3hriu32hrui", "eejf", "iuer", "hrr", "jhwru34iufn" };
        public UserCredentials GenerateCredentials(string password)
        {
            // Gets a random byte array to use as a salt
            var RNGProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[20];
            RNGProvider.GetBytes(salt);
            Random randomNumber = new Random();

            string pepper = Peppers[randomNumber.Next(Peppers.Length - 1)];
            password = pepper + password;
            // converts the password to an array of bytes
            var password_bytes = ASCIIEncoding.ASCII.GetBytes(password);

            byte[] password_and_salt = new byte[password_bytes.Length + salt.Length];

            // Filling the password and salt array with the password_bytes data
            for (int i = 0; i < password_bytes.Length; i++)
            {
                password_and_salt[i] = password_bytes[i];
            }
            // Adding the salt data to the array
            for (int i = 0; i < salt.Length; i++)
            {
                password_and_salt[i + password_bytes.Length] = salt[i];
            }
            // Initializes an instance of the SHA512 provider
            SHA512 SHA = new SHA512Managed();
            // Hashing the password and the salt
            var hashed_arr = SHA.ComputeHash(password_and_salt);

            string hash_result = Convert.ToBase64String(hashed_arr);
            return new UserCredentials { Salt = salt, Password = hash_result };
        }
        public string CondimentPassword(string pepper, string password, byte[] salt)
        {
            password = pepper + password;
            var password_bytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] password_and_salt = new byte[password_bytes.Length + salt.Length];
            // Filling the password and salt array with the password_bytes data
            for (int i = 0; i < password_bytes.Length; i++)
            {
                password_and_salt[i] = password_bytes[i];
            }
            // Adding the salt data to the array
            for (int i = 0; i < salt.Length; i++)
            {
                password_and_salt[i + password_bytes.Length] = salt[i];
            }
            // Initializes an instance of the SHA512 provider
            SHA512 SHA = new SHA512Managed();
            // Hashing the password and the salt
            var hashed_arr = SHA.ComputeHash(password_and_salt);
            string hash_result = Convert.ToBase64String(hashed_arr);
            return hash_result;
        }
    }
    public class Token
    {
        public const string SS_Secret = "jjggyyeennvglkopthcgasfcjj";
        public string GenerateToken(DateTime ExpireDate, string UserId = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var SymetricKey = Convert.FromBase64String(SS_Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new[]
                 {
                        new Claim("USERID",UserId)

                     }),

                Expires = ExpireDate,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(SymetricKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var st = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(st);
            return token;
        }
        private static bool ValidateToken(string token, out IEnumerable<Claim> claims, int? locale = null)
        {
            claims = null;
            var simplePrinciple = GetPrincipal(token);

            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;
            claims = identity.FindAll(c => c.Type == "USERID");
            if (claims == null && claims.Count() < 1) return false;
            return true;
        }
        public Task<IPrincipal> AuthenticateJwtToken(string token, string locale = null)
        {
            IEnumerable<Claim> CLAIMS;

            if (ValidateToken(token, out CLAIMS))
            {
                var claims = new List<Claim>();
                claims.AddRange(CLAIMS);
                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);
        }
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var Token = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (Token == null) return null;
                if (Token.ValidTo < DateTime.UtcNow) return null;
                var SymetricKey = Convert.FromBase64String(SS_Secret);
                var validationParams = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(SymetricKey)
                };
                SecurityToken SecurityToken;
                var principal = tokenHandler.ValidateToken(token, validationParams, out SecurityToken);
                return principal;
            }
            catch (Exception e) { Console.WriteLine(e.Message); return null; }
        }
    }
}