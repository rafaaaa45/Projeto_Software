using BusinessLogic.Models;

namespace Backend.Interface;

public interface IExamAttemptRepository
{
    Task<List<ExamAttemptModel>> GetExamAttempts(long examId);
    
    Task<ExamAttemptModel> CreateExamAttempt(ExamAttemptModel newExamAttempt);
}