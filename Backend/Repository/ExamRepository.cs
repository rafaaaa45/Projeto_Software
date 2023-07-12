using Backend.Interface;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class ExamRepository : IExamRepository
{
    private readonly CertOnlineDbContext _context;

    public ExamRepository(CertOnlineDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ExamModel>> GetExams()
    {
        return await _context.Set<Exam>().Select(exam => new ExamModel() {
            Id = exam.Id,
            CertificationId = exam.CertificationId,
            Name = exam.Name,
            MinimumGrade = exam.MinimumGrade
        }).ToListAsync();
    }

    public async Task<ExamModel> GetExam(long id)
    {
        return _context.Set<Exam>().Select(exam => new ExamModel() {
            Id = exam.Id,
            CertificationId = exam.CertificationId,
            Name = exam.Name,
            MinimumGrade = exam.MinimumGrade
        }).FirstOrDefault(e => e.Id == id);
    }

    public async Task<ExamModel> CreateExam(ExamModel newExam)
    {
        _context.Set<Exam>().Add(new Exam() {
            CertificationId = newExam.CertificationId,
            Name = newExam.Name,
            MinimumGrade = newExam.MinimumGrade
        });
        await _context.SaveChangesAsync();
        return newExam;
    }

    public async Task UpdateExam(ExamModel newExam)
    {
        var exam = await _context.Exams.FirstOrDefaultAsync(u => u.Id == newExam.Id);

        if (exam == null)
        {
            throw new ArgumentException("Exam not found");
        }
        
        exam.CertificationId = newExam.CertificationId;
        exam.Name = newExam.Name;
        exam.MinimumGrade = newExam.MinimumGrade;

        await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteExam(long id)
    {
        var exam = await _context.Exams.FirstOrDefaultAsync(u => u.Id == id);

        if (exam == null)
        {
            throw new ArgumentException("Exam not found");
        }

        _context.Exams.Remove(exam);
        await _context.SaveChangesAsync();

        return _context.SaveChangesAsync().Result;
        
    }
}