
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser(int id);
        Task<int> Create(CreateUserInputModel inputModel);
    }
}
