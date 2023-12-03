using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelance, inputModel.TotalCost);

            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);

            project.Cancel();

            await _dbContext.SaveChangesAsync();
        }

        public async Task Finish(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);

            project.Finish();

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectViewModel>> GetAll(string query)
        {
            var projects =  _dbContext.Projects;

            var projectsViewModel = await projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToListAsync();

            return projectsViewModel;
        }

        public async Task<ProjectDetailsViewModel> GetById(int id)
        {
            var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return null;

            var projectDetailsViewModel =  new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }

        public async Task Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateProjectInputModel inputModel)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

            await _dbContext.SaveChangesAsync();
        }
    }
}
