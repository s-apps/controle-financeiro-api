namespace ControleFinanceiroApi.Models
{
    public class Transaction
    {
        public int? TransactionId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Image { get; set; }
        public double? Amount { get; set; } 
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }

    }
}