using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillViewModel>> GetAll()
        {
            var skill = _dbContext.Skills;

            var skillsViewModel = await skill
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToListAsync();

            return skillsViewModel;
        }
    }
}
