using DevFreela.Core.Enums;

namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, UserRoleEnum role);
        string ComputeSha256Hash(string password);
    }
}
