using Backend.Interface;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class ProfessionalsRepository : IProfessionalRepository
{
    private readonly CertOnlineDbContext _context;

    public ProfessionalsRepository(CertOnlineDbContext context)
    {
        _context = context;
    }


    public async Task<List<ProfessionalModel>> GetProfessionals()
    {
        return await _context.Set<Professional>().Select(professional => new ProfessionalModel() {
            Id = professional.Id,
            Name = professional.Name
        }).ToListAsync();
    }

    public async Task<List<ProfessionalModel>> GetAprovados(int certificationId)
    {
        return await _context.Set<Professional>().Where(p => p.ExamAttempts
            .Any(ea => ea.Grade >= ea.Exam.MinimumGrade && ea.Exam.CertificationId == certificationId))
            .Select(professional => new ProfessionalModel() {
            Id = professional.Id,
            Name = professional.Name
        }).ToListAsync();
    }

    public async Task<List<ProfessionalModel>> GetMelhorNota(int examId)
    {
        var bestGrade = await _context.Set<ExamAttempt>()
            .Where(e => e.ExamId == examId && e.Grade != null)
            .MaxAsync(e => e.Grade);

        var professionals = await _context.Set<Professional>()
            .Where(p => p.ExamAttempts
                .Any(e => e.Exam.Id == examId && e.Grade == bestGrade))
            .Select(professional => new ProfessionalModel()
            {
                Id = professional.Id,
                Name = professional.Name,
                Grade = bestGrade
            }).ToListAsync();

        return professionals;
    }
}