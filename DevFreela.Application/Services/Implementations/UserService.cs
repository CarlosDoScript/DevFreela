using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName,inputModel.Email,inputModel.BirthDate);

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName,user.Email);
        }
    }
}
