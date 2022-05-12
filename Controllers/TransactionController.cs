using ControleFinanceiroApi.Data;
using ControleFinanceiroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TransactionController : ControllerBase
{
    private readonly ControleFinanceiroContext _context;

    public TransactionController(ControleFinanceiroContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransactions()
    {
        var result = await (
            from t in _context.Transactions
            join a in _context.Accounts on t.AccountId equals a.Id
            join c in _context.Categories on t.CategoryId equals c.Id
            where t.UserId == 5
            select new 
            {
                TransactionId = t.Id,
                RegistrationDate = t.RegistrationDate,
                Description = t.Description,
                Amount = t.Amount,
                AccountName = a.AccountName,
                CategoryName = c.CategoryName
            })
            .ToListAsync();
                        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransactionById(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if(transaction == null)
            return NotFound();
        
        return transaction;
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> InsertTransaction(Transaction transaction)
    {
        if(!ModelState.IsValid)
            return NotFound();

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTransactionById", new { id = transaction.Id }, transaction);    
    }
}