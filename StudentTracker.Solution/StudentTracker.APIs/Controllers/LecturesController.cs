using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTracker.APIs.DTOs;
using StudentTracker.Core.Entities;
using StudentTracker.Core.Repositories.Contract;
using StudentTracker.Core.Specifications;
using StudentTracker.Repository.Data;

namespace StudentTracker.APIs.Controllers
{
    public class LecturesController : BaseApiController
    {
        private readonly IGenericRepository<Lecture> _lectureRepo;
        private readonly IMapper _mapper;

        public LecturesController(IGenericRepository<Lecture> lectureRepo, IMapper mapper)
        {
            _lectureRepo = lectureRepo;
            _mapper = mapper;
        }
        [HttpGet("{id}")] // get student lectures of the courses he's enrolled in day by day
        public async Task<ActionResult<IEnumerable<LectureToReturnDto>>> GetStudentLectures(string id)
        {
            string today = DateTime.Now.DayOfWeek.ToString().ToLower();

            var spec = new LectureSpecifications(id, today);
            var lectures = await _lectureRepo.GetAllWithSpecAsync(spec);
            if(!lectures.Any())
                return NotFound("No lectures found for this student");

            return Ok(_mapper.Map<IEnumerable<Lecture>, IEnumerable<LectureToReturnDto>>(lectures));
        }
       
    }
}
