using Backend.Interface;
using BusinessLogic.Context;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalRepository _professionalRepository;

        public ProfessionalController(IProfessionalRepository context)
        {
            _professionalRepository = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProfessionals()
        {
            var getProfessionals = await _professionalRepository.GetProfessionals();
            return Ok(getProfessionals);
        }
        
        [HttpGet("Aprovados")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAprovados(int certificationId)
        {
            var getAprovados = await _professionalRepository.GetAprovados(certificationId);
            return Ok(getAprovados);
        }
        
        [HttpGet("MelhorNota")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetMelhorNota(int examId)
        {
            var getMelhorNota = await _professionalRepository.GetMelhorNota(examId);
            return Ok(getMelhorNota);
        }
    }
}



