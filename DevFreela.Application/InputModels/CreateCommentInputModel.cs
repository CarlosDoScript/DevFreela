using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public record CreateCommentInputModel
    {
        public CreateCommentInputModel(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; init; }
        public int IdProject { get; init; }
        public int IdUser { get; init; }
    }
}
