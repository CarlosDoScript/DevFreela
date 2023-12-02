namespace DevFreela.Application.InputModels
{
    public record NewProjectInputModel
    {
        public NewProjectInputModel(string title, string description, int idClient, int idFreelance, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelance = idFreelance;
            TotalCost = totalCost;
        }

        public string Title { get; init; }
        public string Description { get; init; }
        public int IdClient { get; init; }
        public int IdFreelance { get; init; }
        public decimal TotalCost { get; init; }
    }
}
