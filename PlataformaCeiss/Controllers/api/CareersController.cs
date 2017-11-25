using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlataformaCeiss.Controllers.api
{
    public class CareersController : ApiController
    {
        [Route("api/GetCareers"), HttpGet]
        public object GetCarreers()
        {
            using (var context = new CEISSContext())
            {
                var results = context.Careers.Select(d => new
                {
                    carreerID = d.CareerId,
                    code = d.CareerCode,
                    name = d.CareerName
                }).ToList();

                if (results != null)
                    return Request.CreateResponse(HttpStatusCode.OK, results);
                else return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
    }
}
