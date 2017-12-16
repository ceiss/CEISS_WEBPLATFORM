using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace PlataformaCeiss.Services
{
    public class CeissAuth : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization.Scheme;
            var tokenHandler = new Token();

            try
            {
                Thread.CurrentPrincipal = tokenHandler.AuthenticateJwtToken(token).Result;

            }
            catch (Exception e)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}