using BusinessLogic.Models;

namespace Backend.Interface;

public interface IProfessionalRepository
{
    Task<List<ProfessionalModel>> GetProfessionals();

    Task<List<ProfessionalModel>> GetAprovados(int certificationId);
    
    Task<List<ProfessionalModel>> GetMelhorNota(int examId);
}