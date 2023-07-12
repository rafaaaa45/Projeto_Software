using Backend.Interface;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class ExamAttemptRepository : IExamAttemptRepository
{
    private readonly CertOnlineDbContext _context;

    public ExamAttemptRepository(CertOnlineDbContext context)
    {
        _context = context;
    }


    public async Task<List<ExamAttemptModel>> GetExamAttempts(long examId)
    {
        return await _context.Set<ExamAttempt>().Where(e => e.ExamId == examId).Select(examAttempt => new ExamAttemptModel() {
            Id = examAttempt.Id,
            ExamId = examAttempt.ExamId,
            ProfessionalId = examAttempt.ProfessionalId,
            AttemptName = examAttempt.AttemptName,
            Grade = examAttempt.Grade,
            AttemptDate = examAttempt.AttemptDate
        }).ToListAsync();
    }

    public async Task<ExamAttemptModel> CreateExamAttempt(ExamAttemptModel newExamAttempt)
    {
        _context.Set<ExamAttempt>().Add(new ExamAttempt() {
            ExamId = newExamAttempt.ExamId,
            ProfessionalId = newExamAttempt.ProfessionalId,
            AttemptName = newExamAttempt.AttemptName,
            Grade = newExamAttempt.Grade,
            AttemptDate = newExamAttempt.AttemptDate
        });
        await _context.SaveChangesAsync();
        return newExamAttempt;
    }
}