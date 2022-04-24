using ControleFinanceiroApi.Data;
using ControleFinanceiroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
	    private readonly ControleFinanceiroContext _context;
	    public CategoryController(ControleFinanceiroContext context)
	    {
		    _context = context;
	    }

	    [HttpGet]
	    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
	    {
		    return await _context.Categories.ToListAsync();
	    }

        [HttpPost]
        public async Task<ActionResult<Category>> InsertCategory(Category category)
        {
            if (!ModelState.IsValid)
                return NotFound();

		    _context.Categories.Add(category);
		    await _context.SaveChangesAsync();
		    return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }


}
