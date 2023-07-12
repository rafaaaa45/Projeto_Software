using Backend.Interface;
using Backend.Repository;
using BusinessLogic.Context;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationController(ICertificationRepository context)
        {
            _certificationRepository = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCertifications()
        {
            var getCertifications = await _certificationRepository.GetCertifications();
            return Ok(getCertifications);
        }
    }
}