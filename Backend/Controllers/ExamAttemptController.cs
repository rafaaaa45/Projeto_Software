using Backend.Interface;
using BusinessLogic.Context;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Entities;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamAttemptController : ControllerBase
    {
        private readonly IExamAttemptRepository _examAttemptRepository;

        public ExamAttemptController(IExamAttemptRepository context)
        {
            _examAttemptRepository = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetExamAttempts(long examId)
        {
            var examAttempts = await _examAttemptRepository.GetExamAttempts(examId);
            return Ok(examAttempts);
        } 
        
        [HttpPost]
        public async Task<IActionResult> CreateExamAttempt([FromBody] ExamAttemptModel newExamAttempt)
        {
            if (ModelState.IsValid)
            {
                var examAttempt = await _examAttemptRepository.CreateExamAttempt(newExamAttempt);
                return Ok(examAttempt);
            }

            return BadRequest("Something went wrong!!");
        }
    }
}