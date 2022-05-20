namespace ControleFinanceiroApi.Models
{
    public class Category
    {
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
