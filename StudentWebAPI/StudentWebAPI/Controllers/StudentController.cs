using Microsoft.AspNetCore.Mvc;

using StudentWebAPI.Models;

namespace StudentWebAPI.Controllers
{
    public class StudentController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class StudentsController : ControllerBase
        {
            private readonly IStudentRepository _studentRepository;

            public StudentsController(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            [HttpGet("{id}")]
            public ActionResult<Student> Get(string code)
            {
                var student = _studentRepository.GetStudentById(code);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }

            [HttpPost]
            public ActionResult<Student> Post(string code, string name, string lastName, string documentType, string documentNumber, string status, string gender, string imageRef)
            {

                var createdStudent = _studentRepository.CreateStudent(code, name, lastName, documentType, documentNumber, status,gender,imageRef);

                return CreatedAtAction(nameof(Get), new { id = createdStudent.Code }, createdStudent);
            }

            [HttpPatch("{id}")]
            public ActionResult<Student> Patch(string code, string name, string lastName, string documentType, string documentNumber, string status, string gender, string imageRef)
            {
                var existingStudent = _studentRepository.GetStudentById(code);

                if (existingStudent == null)
                {
                    return NotFound();
                }

                existingStudent.Name = name;
                existingStudent.LastName = lastName;
                existingStudent.DocumentType = documentType;
                existingStudent.DocumentNumber = documentNumber;
                existingStudent.Gender = gender;
                existingStudent.Status = status;
                existingStudent.ImageRef = imageRef;


                var updatedStudent = _studentRepository.UpdateStudent(code, name, lastName, documentType, documentNumber, status, gender, imageRef);

                return Ok(updatedStudent);
            }

        }
    }
}
