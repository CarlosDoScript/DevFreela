using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public record CommentProjectViewModel
    {
        public CommentProjectViewModel(int id, string content, string userName, int idProject, int idUser, DateTime commentDate)
        {
            Id = id;
            Content = content;
            UserName = userName;
            IdProject = idProject;
            IdUser = idUser;
            CommentDate = commentDate;
        }

        public int Id { get; init; }
        public string Content { get; init; }
        public string UserName { get; init; }
        public int IdProject { get; init; }
        public int IdUser { get; init; }
        public DateTime CommentDate { get; init; }
    }
}
