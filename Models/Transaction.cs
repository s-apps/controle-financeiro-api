
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroApi.Models;

public class Transaction {

    public int Id { set; get; }

    public int UserId { set; get; }

    public int AccountId { set; get; }

    public int CategoryId { set; get; }

    [Required]
    public string? Type { set; get; }
    
    [Required]
    public DateTime? RegistrationDate { set; get; }

    public DateTime? ExpirationDate { set; get; }

    public DateTime? PaymentDate { set; get; }

    [Required]
    public double? Amount { set; get; }

    [Column(TypeName = "varchar(80)")]
    [Required]
    public string? Description { get; set; }

}