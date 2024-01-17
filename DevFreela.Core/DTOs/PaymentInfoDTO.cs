namespace DevFreela.Core.DTOs
{
    public record PaymentInfoDTO
    {
        public PaymentInfoDTO(int idProject, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
        {
            IdProject = idProject;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Amount = amount;
        }

        public int IdProject { get; init; }
        public string CreditCardNumber { get; init; }
        public string Cvv { get; init; }
        public string ExpiresAt { get; init; }
        public string FullName { get; init; }
        public decimal Amount { get; init; }
    }
}
