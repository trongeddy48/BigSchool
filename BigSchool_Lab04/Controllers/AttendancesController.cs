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
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchool_Lab04Context context = new BigSchool_Lab04Context();
            if(context.Attendances.Any(p => p.Attendee == userID && p.CourseId == attendanceDto.Id))
            {
                return BadRequest("The attendance already exists !");
            }
            var attendance = new Attendance() { CourseId = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
    }
}
