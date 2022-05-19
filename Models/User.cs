namespace ControleFinanceiroApi.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string? FullName { get; set; }   
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
