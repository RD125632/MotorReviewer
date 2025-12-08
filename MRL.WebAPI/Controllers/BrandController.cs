using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRL.Shared.Contracts;
using MRL.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(MotorcyclesContext context) : ControllerBase
    {
        private readonly MotorcyclesContext _context = context;

        // helper: map EF entity -> DTO
        private static BrandDTO ToDto(Brand brand) => new()
        {
            Id = brand.Id,
            Name = brand.Name
        };

        // helper: map DTO -> EF entity (for create/update)
        private static void UpdateEntityFromDto(Brand entity, BrandDTO dto)
        {
            entity.Name = dto.Name;
        }

        #region HTTP Calls

        // GET: api/brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAll()
        {
            var result = await _context.Brands.Select(b => ToDto(b)).ToListAsync();
            return Ok(result);
        }

        // GET api/brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetById(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
                return NotFound();

            return Ok(ToDto(brand));
        }

        // POST api/brands
        [HttpPost]
        public async Task<ActionResult<BrandDTO>> Create(BrandDTO dto)
        {
            var brand = new Brand();
            UpdateEntityFromDto(brand, dto);

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            var resultDto = ToDto(brand);

            // Returns 201 + Location header
            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, resultDto);
        }

        // PUT: api/brands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BrandDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and body do not match.");

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            UpdateEntityFromDto(brand, dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Brands.AnyAsync(b => b.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
