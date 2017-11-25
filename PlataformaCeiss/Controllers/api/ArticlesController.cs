using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlataformaCeiss.Controllers.api
{
    public class ArticlesController : ApiController
    {
        [HttpGet,Route("api/Articles/GetArticles/{page}")]
        public object GetArticles(int page)
        {

            using (var context = new CEISSContext(false))
            {
                int postPerPage = 6;
                page = page - 1;
                var Articles = context.Articles
                                      .OrderByDescending(o => o.PublishDate)
                                      .Skip(postPerPage * page)
                                      .Take(postPerPage)
                                      .Select(d => new
                                      {
                                          d.Title,
                                          d.Preview,
                                          d.PrimaryImage,
                                          author = new
                                          {
                                              name = d.Author.FirstName,
                                              lastname = d.Author.FirstLastName,
                                          }
                                      }).FirstOrDefault();
                return Articles;

                  }



        }



    }
}
