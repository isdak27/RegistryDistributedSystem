using Microsoft.AspNetCore.Mvc;
using SubjectWebAPI.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class SubjectsController : ControllerBase
        {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Subject> Get(string code)
        {
            var subject = _subjectRepository.GetSubjectById(code);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public ActionResult<Subject> Post(string code, string name, int group, int quotas, string actualStatus)
        {

            var createdSubject = _subjectRepository.CreateSubject(code, name, group, quotas, actualStatus);

            return CreatedAtAction(nameof(Get), new { id = createdSubject.Code }, createdSubject);
        }

        [HttpPatch("{id}")]
        public ActionResult<Subject> Patch(string code, string name, int group, int quotas, string actualStatus)
        {
            var existingSubject = _subjectRepository.GetSubjectById(code);

            if (existingSubject == null)
            {
                return NotFound();
            }

            existingSubject.Name = name;
            existingSubject.Group = group;
            existingSubject.Quotas = quotas;
            existingSubject.ActualStatus = actualStatus;

            var updatedSubject = _subjectRepository.UpdateSubject(code, name, group, quotas, actualStatus);

            return Ok(updatedSubject);
        }

    }
}
