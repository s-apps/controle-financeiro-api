namespace ControleFinanceiroApi.Models
{
    public class Account
    {
        public int? AccountId { get; set; }
        public string? Description { get; set; }
        public double? Balance { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}