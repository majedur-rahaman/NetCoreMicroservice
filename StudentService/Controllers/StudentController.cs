using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Models;
using StudentService.Service;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public ActionResult GetStudents()
        {
            var students =  _studentRepository.GetStudents();
            if(students == null)
                return NotFound();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var stduent = _studentRepository.GetStudent(id);
            if(stduent == null)
                return NotFound();
            return Ok(stduent);
        }
    }
}

