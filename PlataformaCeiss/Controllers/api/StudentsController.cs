using Classes;
using Datamodel;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlataformaCeiss.Controllers.api
{
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {

        [HttpGet, Route("getStudentsByFirstName/{name}")]
        public HttpResponseMessage getStudentsByFirstName(string name)
        {
            using (var context = new CEISSContext())
            {
                var Students =
                    context.Students
                           .Where(student => student.FirstName == name)
                           .ToList();

                /*
                 
                 Other ways to query the database:

                 var Students_ = (from s in context.Students
                                  where s.FirstName == name
                                  select s).ToList();
                 
                 var Students_ = (from s in context.Students
                                  where s.FirstName == name
                                  select s).ToList();
                                
                 var _STUDENTS = context.Database.SqlQuery<Student>("SELECT * FROM USERS").ToList();

                 */

                return Request.CreateResponse(HttpStatusCode.OK, Students);

            }
        }

        public class StudentDTO
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string FirstLastName { get; set; }
            public string SecondLastName { get; set; }
            public string Email { get; set; }
            public string Cellphone { get; set; }
            public string Phone { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime CreationDate { get; set; }
            public int CareerID { get; set; }
        }

        [HttpPost, Route("CreateStudent")]
        public HttpResponseMessage CreateStudent([FromBody]StudentDTO newStudent)
        {
            using (var context = new CEISSContext())
            {
                try
                {
                    context.Students.Add(new Student
                    {
                        BirthDate = newStudent.BirthDate,
                        Email = newStudent.Email,
                        CreationDate = DateTime.UtcNow,
                        CareerID = newStudent.CareerID,
                        Cellphone = newStudent.Cellphone,
                        FirstName = newStudent.FirstName,
                        SecondName = newStudent.SecondName,
                        FirstLastName = newStudent.FirstLastName,
                        SecondLastName = newStudent.SecondLastName,
                        Phone = newStudent.Phone,
                    });
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }


        [HttpPut, Route("CreateStudent/{studentID}")]
        public HttpResponseMessage UpdateStudent([FromUri] int studentID, [FromBody]StudentDTO StudentChanges)
        {
            using (var context = new CEISSContext())
            {
                try
                {
                    var StudentInDb = context.Students.Where(U => U.StudentID == studentID).FirstOrDefault();
                    if (StudentInDb != null)
                    {
                        StudentInDb.BirthDate = StudentChanges.BirthDate;
                        context.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotFound);

                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }

        [HttpDelete, Route("DeleteStudent/{studentID}")]
        public HttpResponseMessage DeleteStudent([FromUri] int studentID)
        {
            using (var context = new CEISSContext())
            {
                try
                {
                    var StudentInDb = context.Students.Where(U => U.StudentID == studentID).FirstOrDefault();
                    if (StudentInDb != null)
                    {
                        context.Students.Remove(StudentInDb);
                        context.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotFound);

                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
