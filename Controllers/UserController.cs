using ControleFinanceiroApi.Data;
using ControleFinanceiroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly ControleFinanceiroContext _context;
	public UserController(ControleFinanceiroContext context)
	{
		_context = context;
	}
	
	[HttpGet]
	public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
	{
		return await _context.Users.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<User>> GetUserById(int id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null) 
			return NotFound();

		return user;
	}

	[HttpPost]
	public async Task<ActionResult<User>> InsertUser(User user)
	{
		user.Created_at = DateTime.Now;
		_context.Users.Add(user);
		await _context.SaveChangesAsync();
		return CreatedAtAction("GetUserById", new { id = user.Id }, user);
	}

	[HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

		user.Updated_at = DateTime.Now;
        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
	private bool UserExists(int id)
    {
        return _context.Users.Any(user => user.Id == id);
    }
}
