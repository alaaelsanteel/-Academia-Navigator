using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTracker.APIs.DTOs;
using StudentTracker.APIs.Errors;
using StudentTracker.Core.Entities;
using StudentTracker.Core.Repositories.Contract;
using StudentTracker.Core.Specifications;

namespace StudentTracker.APIs.Controllers
{
    public class StudentsController : BaseApiController
    {
        //The generic of Student database.
        private readonly IGenericRepository<Student> _studentRepo;
        private readonly IMapper _mapper;

        public StudentsController(IGenericRepository<Student> studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]       //get student's data using his ID.
        public async Task<ActionResult<StudentToReturnDto>> GetStudent(string id)
        {
            var spec = new StudentSpecifications(id);
            var student = await _studentRepo.GetWithSpecAsync(spec);

            if(student == null) 
            { 
                return NotFound(new ApiResponse(404));
            }

            return Ok(_mapper.Map<StudentToReturnDto>(student));
        }
        [HttpPost("add-face-id")] //add student face id
        public async Task<ActionResult> AddStudentPicUrl(StudentFaceIdDto studentFaceIdDto)
        {
            var student = await _studentRepo.FirstOrDefaultAsync(s => s.NationalId == studentFaceIdDto.id);
            if (student == null)
            {
                return NotFound("Student not found.");

            }
            
            student.FaceId = studentFaceIdDto.faceId;
            _studentRepo.Update(student);
            await _studentRepo.SaveChangesAsync();
            return Ok("Student Picture Face data Added.");
        }
        [HttpGet("get-face-id/{id}")] //get student face id using his ID
        public async Task<ActionResult> GetStudentPicUrl(string id)
        {
            var student = await _studentRepo.FirstOrDefaultAsync(s => s.NationalId == id);
            if (student == null)
            {
                return NotFound("Student with {id} not found.");

            }
            if (string.IsNullOrEmpty(student.FaceId))
            {
                return NotFound("No image URL available for this student.");
            }
            return Ok(student.FaceId);

        }
    }
}
