using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiroApi.Models;
public class User
{
	public int Id { get; set; }
	[Column(TypeName = "varchar(50)")]
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }
	public DateTime? Created_at { get; set; }
	public DateTime? Updated_at { get; set; }
}