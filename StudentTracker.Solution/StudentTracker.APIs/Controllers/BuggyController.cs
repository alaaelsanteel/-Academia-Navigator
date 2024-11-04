using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTracker.Repository.Data;

namespace StudentTracker.APIs.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly TrackerContext _dbContext;

        public BuggyController(TrackerContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var student = _dbContext.Students.Find(100);
            if(student == null) return NotFound();
            return Ok(student);
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var student = _dbContext.Students.Find(100);
            var studentToReturn= student.ToString(); //exception [NullReferenceException]

            return Ok(studentToReturn);
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("badrequest/{id}")] //badrequest/five
        public ActionResult GetBadRequest(int id)//Validation Error
        {
            return Ok();
        }
    }
}
