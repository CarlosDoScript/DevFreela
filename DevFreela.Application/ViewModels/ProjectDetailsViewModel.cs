using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public record ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt,string clientFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public decimal TotalCost { get; init; }
        public DateTime? StartedAt { get; init; }
        public DateTime? FinishedAt { get; init; }
        public string ClientFullName { get; init; }
        public string FreelancerFullName { get; init; }
    }
}
