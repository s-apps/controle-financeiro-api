using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroApi.Models;
public class Account
{
    public int Id { get;set; }

    [Column(TypeName = "varchar(80)")]
    [Required]
    public string? AccountName { get; set; }

    [Required]
    public double? Balance { get; set; }

    public virtual User? User { get; set; }
    
}