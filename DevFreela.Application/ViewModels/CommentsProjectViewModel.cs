using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public record CommentsProjectViewModel
    {
        public CommentsProjectViewModel(string content, string clientName, string freelancerName, string titleProject, string descriptionProject, int idProject, int idUser, DateTime createdAt)
        {
            Content = content;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TitleProject = titleProject;
            DescriptionProject = descriptionProject;
            IdProject = idProject;
            IdUser = idUser;
            CreatedAt = createdAt;
        }

        public string Content { get; init; }
        public string ClientName { get; init; }
        public string FreelancerName { get; init; }
        public string TitleProject { get; init; }
        public string DescriptionProject { get; init; }
        public int IdProject { get; init; }
        public int IdUser { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
