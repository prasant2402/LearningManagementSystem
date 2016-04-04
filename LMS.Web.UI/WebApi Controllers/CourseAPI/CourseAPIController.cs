using LMS.Data.BL;
using LMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMS.Web.UI.WebApi_Controllers.CourseAPI
{
    public class CourseAPIController : ApiController
    {
        ICourse _course;

        [HttpGet]
        [ActionName("GetAllCourses")]
        public async Task<Acknowledgement<Course>> GetAllCourses()
        {
            _course = new CourseBLC();
            return await _course.GetAll();
        }

        [HttpPost]
        [ActionName("AddCourse")]
        public async Task<Acknowledgement<Course>> Post(Course course)
        {
            _course = new CourseBLC();
            return await _course.CreateRecord(course);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}