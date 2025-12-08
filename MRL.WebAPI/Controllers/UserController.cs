using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRL.Shared.Contracts;
using MRL.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(MotorcyclesContext context) : ControllerBase
    {
        private readonly MotorcyclesContext _context = context;

        // helper: map EF entity -> DTO
        private static UserDTO ToDto(User User) => new()
        {
            Id = User.Id,
            Name = User.Name,
            ExperienceLevel = User.ExperienceLevel
        };

        // helper: map DTO -> EF entity (for create/update)
        private static void UpdateEntityFromDto(User entity, UserDTO dto)
        {
            entity.Name = dto.Name;
            entity.ExperienceLevel = dto.ExperienceLevel;
        }

        #region HTTP Calls

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var result = await _context.Users.Select(b => ToDto(b)).ToListAsync();
            return Ok(result);
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User == null)
                return NotFound();

            return Ok(ToDto(User));
        }

        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(UserDTO dto)
        {
            var User = new User();
            UpdateEntityFromDto(User, dto);

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            var resultDto = ToDto(User);

            // Returns 201 + Location header
            return CreatedAtAction(nameof(GetById), new { id = User.Id }, resultDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and body do not match.");

            var User = await _context.Users.FindAsync(id);
            if (User == null)
                return NotFound();

            UpdateEntityFromDto(User, dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Users.AnyAsync(b => b.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null)
                return NotFound();

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
