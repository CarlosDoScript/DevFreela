using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectViewModel>> GetAll(string query);
        Task<ProjectDetailsViewModel> GetById(int id);
    }
}
