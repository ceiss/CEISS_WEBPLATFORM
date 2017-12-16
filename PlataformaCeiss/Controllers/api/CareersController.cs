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
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                var results = context.Careers.Select(d => new
                {
                    carreerID = d.CareerId,
                    code = d.CareerCode,
                    students = context.Students.Where(s=>s.Career.CareerId==d.CareerId).ToList(),
                    name = d.CareerName
                }).ToList();

                if (results != null)
                    return Request.CreateResponse(HttpStatusCode.OK, results);
                else return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }
    }
}
