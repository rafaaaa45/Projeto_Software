using BusinessLogic.Models;

namespace Backend.Interface;

public interface ICertificationRepository
{
    Task<List<CertificationModel>> GetCertifications();
}