using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroApi.Models;
public class Category
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(80)")]
	[Required]
    public string? CategoryName { get; set; }

    [Column(TypeName = "varchar(7)")]
    [Required]
    public string? CategoryType { get; set; }

    public int UserId { get; set; }
    
    public virtual User? User { get; set; }
}