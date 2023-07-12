using Backend.Interface;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class CertificationRepository : ICertificationRepository
{
    private readonly CertOnlineDbContext _context;

    public CertificationRepository(CertOnlineDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CertificationModel>> GetCertifications() {
        return await _context.Set<Certification>().Select(certification => new CertificationModel() {
            Id = certification.Id,
            Name = certification.Name
        }).ToListAsync();
    }
}