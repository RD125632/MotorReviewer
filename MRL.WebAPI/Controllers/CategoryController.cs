using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRL.Shared.Contracts;
using MRL.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(MotorcyclesContext context) : ControllerBase
    {
        private readonly MotorcyclesContext _context = context;

        // helper: map EF entity -> DTO
        private static CategoryDTO ToDto(Category category) => new()
        {
            Id = category.Id,
            Name = category.Name
        };

        // helper: map DTO -> EF entity (for create/update)
        private static void UpdateEntityFromDto(Category entity, CategoryDTO dto)
        {
            entity.Name = dto.Name;
        }

        #region HTTP Calls

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            var result = await _context.Categories.Select(b => ToDto(b)).ToListAsync();
            return Ok(result);
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var result = await _context.Categories.FindAsync(id);

            if (result == null)
                return NotFound();

            return Ok(ToDto(result));
        }

        // POST api/category
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO dto)
        {
            var result = new Category();
            UpdateEntityFromDto(result, dto);

            _context.Categories.Add(result);
            await _context.SaveChangesAsync();

            var resultDto = ToDto(result);

            // Returns 201 + Location header
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, resultDto);
        }

        // PUT: api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and body do not match.");

            var result = await _context.Categories.FindAsync(id);
            if (result == null)
                return NotFound();

            UpdateEntityFromDto(result, dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Categories.AnyAsync(b => b.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Categories.FindAsync(id);
            if (result == null)
                return NotFound();

            _context.Categories.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
