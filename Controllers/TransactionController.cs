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
        var result = await _context.Transactions
            .Join(
                _context.Accounts,
                transaction => transaction.AccountId,
                account => account.Id,
                (transaction, account) => new
                {
                    TransactionId = transaction.Id,
                    AccountId = account.Id,
                    AccountName = account.AccountName,
                    CategoryId = transaction.CategoryId
                }
            )
            .Join(
                _context.Categories,
                transaction => transaction.CategoryId,
                category => category.Id,
                (transaction, category) => new
                {
                    TransactionId = transaction.TransactionId,
                    CategoryName = category.CategoryName,
                    CategoryType = category.CategoryType
                }
            ).ToListAsync();      
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