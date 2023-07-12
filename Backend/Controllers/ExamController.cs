using Backend.Interface;
using BusinessLogic.Context;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Entities;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamController : ControllerBase
{
    private readonly IExamRepository _examRepository;

        public ExamController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        // GET: api/Activity
        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var exams = await _examRepository.GetExams();
            return Ok(exams);
        }   

        // GET: api/Activity
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExam(long id)
        {
            var exam = await _examRepository.GetExam(id);

            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        // POST: api/Activity
        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] ExamModel newExam)
        {
            if (ModelState.IsValid)
            {
                var exam = await _examRepository.CreateExam(newExam);
                return Ok(exam);
            }

            return BadRequest("Something went wrong!!");
        }
        
        // PUT: api/Activity/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(long id, [FromBody] ExamModel updatedExam)
        { 
            if (id != updatedExam.Id)
            {
                return BadRequest("Exam Not Found!");
            }

            await _examRepository.UpdateExam(updatedExam);

            return NoContent();
        }
        
        
        // DELETE: api/Activity/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(long id)
        {
            int exam = await _examRepository.DeleteExam(id);

            if (exam == 200)
            {
                return Ok();
            }
            
            return NoContent();
        }
        
    }