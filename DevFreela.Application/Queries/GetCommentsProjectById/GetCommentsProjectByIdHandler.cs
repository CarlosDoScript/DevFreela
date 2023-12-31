﻿using DevFreela.Application.ViewModels;
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
    public class GetCommentsProjectByIdHandler : IRequestHandler<GetCommentsProjectByIdQuery, List<CommentProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetCommentsProjectByIdHandler(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<CommentProjectViewModel>> Handle(GetCommentsProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projectComment = await _projectRepository.GetAllCommentProjectByIdAsync(request.Id);

            if (projectComment == null)
                return null;

            var projectComments = projectComment
              .Select(c => new CommentProjectViewModel(
                  c.Id,
                  c.Content,
                  c.User.FullName,
                  c.IdProject,
                  c.IdUser,
                  c.CreatedAt
                  ))
              .ToList();


            return projectComments;
        }
    }
}
