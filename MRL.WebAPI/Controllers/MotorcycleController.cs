using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRL.Shared.Contracts;
using MRL.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController(MotorcyclesContext context) : ControllerBase
    {
        private readonly MotorcyclesContext _context = context;

        // helper: map EF entity -> DTO
        private static MotorcycleDTO ToDto(Motorcycle Motorcycle) => new()
        {
            Id = Motorcycle.Id,
            BrandId = Motorcycle.BrandId,
            CategoryId = Motorcycle.CategoryId,
            Model = Motorcycle.Model,
            Year = Motorcycle.Year,
            EngineCc = Motorcycle.EngineCc,
            PowerHp = Motorcycle.PowerHp
        };

        // helper: map DTO -> EF entity (for create/update)
        private static void UpdateEntityFromDto(Motorcycle entity, MotorcycleDTO dto)
        {
            entity.BrandId = dto.BrandId;
            entity.CategoryId = dto.CategoryId;
            entity.Model = dto.Model;
            entity.Year = dto.Year;
            entity.EngineCc = dto.EngineCc;
            entity.PowerHp = dto.PowerHp;
        }

        #region HTTP Calls

        // GET: api/Motorcycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorcycleDTO>>> GetAll()
        {
            var result = await _context.Motorcycles.Select(b => ToDto(b)).ToListAsync();
            return Ok(result);
        }

        // GET api/Motorcycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotorcycleDTO>> GetById(int id)
        {
            var Motorcycle = await _context.Motorcycles.FindAsync(id);

            if (Motorcycle == null)
                return NotFound();

            return Ok(ToDto(Motorcycle));
        }

        // POST api/Motorcycles
        [HttpPost]
        public async Task<ActionResult<MotorcycleDTO>> Create(MotorcycleDTO dto)
        {
            var Motorcycle = new Motorcycle();
            UpdateEntityFromDto(Motorcycle, dto);

            _context.Motorcycles.Add(Motorcycle);
            await _context.SaveChangesAsync();

            var resultDto = ToDto(Motorcycle);

            // Returns 201 + Location header
            return CreatedAtAction(nameof(GetById), new { id = Motorcycle.Id }, resultDto);
        }

        // PUT: api/Motorcycles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MotorcycleDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and body do not match.");

            var Motorcycle = await _context.Motorcycles.FindAsync(id);
            if (Motorcycle == null)
                return NotFound();

            UpdateEntityFromDto(Motorcycle, dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Motorcycles.AnyAsync(b => b.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Motorcycles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Motorcycle = await _context.Motorcycles.FindAsync(id);
            if (Motorcycle == null)
                return NotFound();

            _context.Motorcycles.Remove(Motorcycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
