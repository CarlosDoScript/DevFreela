using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetCommentsProjectById
{
    public class GetCommentsProjectByIdHandler : IRequestHandler<GetCommentsProjectByIdQuery, List<CommentsProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetCommentsProjectByIdHandler(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<CommentsProjectViewModel>> Handle(GetCommentsProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projectComment = await _projectRepository.GetAllCommentsProjectById(request.Id);

            if (projectComment == null)
                return null;

            var projectComments = projectComment
              .Select(c => new CommentsProjectViewModel(
                  c.Content,
                  c.Project.Client.FullName,
                  c.Project.Freelancer.FullName,
                  c.Project.Title,
                  c.Project.Description,
                  c.IdProject,
                  c.IdUser,
                  c.CreatedAt
                  ))
              .ToList();


            return projectComments;
        }
    }
}
