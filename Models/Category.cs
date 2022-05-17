namespace ControleFinanceiroApi.Models
{
    public class Category
    {
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
