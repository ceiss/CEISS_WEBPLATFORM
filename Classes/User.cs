using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes
{
    [Table("USERS")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(30), Required]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string SecondName { get; set; }
        [StringLength(30), Required]
        public string FirstLastName { get; set; }
        [StringLength(30)]
        public string SecondLastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Cellphone { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public Byte[] Salt { get; set; }
        public Career Career { get; set; }
    }
}
