using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateCommentProject
{
    public class CreateCommentProjectHandler : IRequestHandler<CreateCommentProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateCommentProjectHandler(DevFreelaDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Unit> Handle(CreateCommentProjectCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;   
        }
    }
}
