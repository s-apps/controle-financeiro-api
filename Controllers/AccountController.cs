using ControleFinanceiroApi.Data;
using ControleFinanceiroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ControleFinanceiroContext _context;
    public AccountController(ControleFinanceiroContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAllAccounts()
    {
        return await _context.Accounts.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Account>> InsertAccount(Account account)
    {
        if (!ModelState.IsValid)
            return NotFound();

		_context.Accounts.Add(account);
		await _context.SaveChangesAsync();
		return Ok(account);

    }

}