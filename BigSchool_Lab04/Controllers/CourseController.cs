using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool_Lab04.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool_Lab04.Controllers
{
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/DeteleCourse")]
        public IHttpActionResult DeteleCourse(int id)
        {
            BigSchool_Lab04Context context = new BigSchool_Lab04Context();
            var userId = User.Identity.GetUserId();
            var course = context.Courses.Single(c => c.Id == id && c.LecturerId == userId);

            try
            {
                var Attend = context.Attendances.Single(p => p.Attendee == userId && p.CourseId == id);
                context.Attendances.Remove(Attend);
                context.Courses.Remove(course);
                context.SaveChanges();
                return Json(new
                {
                    check = "Ok"
                });
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return Json(new
                {
                    check = "Null"
                });
            }
        }
    }
}