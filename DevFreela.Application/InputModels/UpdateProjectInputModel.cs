using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public record UpdateProjectInputModel
    {
        public UpdateProjectInputModel(int id,string title, string description, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public decimal TotalCost { get; init; }
    }
}
