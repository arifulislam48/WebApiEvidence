using Evidence_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Evidence_10.Controllers
{
    public class StudentController : ApiController
    {
        RepositoryStudent db = new RepositoryStudent();

        // GET: api/Student
        [Authentication.BasicAuthentication]
        public IEnumerable<StudentVM> GetAllStudent()
        {
            return db.getAll().ToList();
        }

        [ResponseType(typeof(StudentVM))]
        // GET: api/Student/5
        public IHttpActionResult GetStudent(int id)
        {
            StudentVM student = db.get(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student
        [ResponseType(typeof(StudentVM))]
        public IHttpActionResult PutStudent(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentVM stVM = db.update(student);

            return Ok(stVM);
        }

        // POST: api/Student
        [ResponseType(typeof(StudentVM))]
        public IHttpActionResult PostStudent(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentVM stVM = db.create(student);
            return Ok(stVM);


        }

        // DELETE: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteStudent(int id)
        {
            if (id > 0)
            {
                db.remove(id);
                return Ok();
            }
            return StatusCode(HttpStatusCode.BadRequest);
        }
    }
}
