using BusinessLogic.Models;

namespace Backend.Interface;

public interface IExamRepository
{
    Task<List<ExamModel>> GetExams();
    Task<ExamModel> GetExam(long id);
    Task<ExamModel> CreateExam(ExamModel newExam);
    Task UpdateExam(ExamModel newExam);
    Task<int> DeleteExam(long id);
}