using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiroApi.Models;
public class User
{
	public int Id { get; set; }

	[Column(TypeName = "varchar(50)")]
	[Required]
	public string? Name { get; set; }

	[Required]
	public string? Email { get; set; }

	[Required]
	public string? Password { get; set; }

	public DateTime? Created_at { get; set; }

	public DateTime? Updated_at { get; set; }
	
	public virtual List<Category>? Categories { get; set; }
}