using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRL.Shared.Contracts;
using MRL.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MRL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(MotorcyclesContext context) : ControllerBase
    {
        private readonly MotorcyclesContext _context = context;

        // helper: map EF entity -> DTO
        private static ReviewDTO ToDto(Review Review) => new()
        {
            Id = Review.Id,
            MotorcycleId = Review.MotorcycleId,
            UserId = Review.UserId,
            ReviewDate = Review.ReviewDate,
            HandlingScore = Review.HandlingScore,
            SpeedScore = Review.SpeedScore,
            ComfortScore = Review.ComfortScore,
            BrakesScore = Review.BrakesScore,
            StabilityScore = Review.StabilityScore,
            ValueScore = Review.ValueScore,
            OverallScore = Review.OverallScore,
            Comment = Review.Comment
        };

        // helper: map DTO -> EF entity (for create/update)
        private static void UpdateEntityFromDto(Review entity, ReviewDTO dto)
        {
            entity.MotorcycleId = dto.MotorcycleId;
            entity.UserId = dto.UserId;
            entity.ReviewDate = dto.ReviewDate;
            entity.HandlingScore = dto.HandlingScore;
            entity.SpeedScore = dto.SpeedScore;
            entity.ComfortScore = dto.ComfortScore;
            entity.BrakesScore = dto.BrakesScore;
            entity.StabilityScore = dto.StabilityScore;
            entity.ValueScore = dto.ValueScore;
            entity.OverallScore = dto.OverallScore;
            entity.Comment = dto.Comment;
        }

        #region HTTP Calls

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll()
        {
            var result = await _context.Reviews.Select(b => ToDto(b)).ToListAsync();
            return Ok(result);
        }

        // GET api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetById(int id)
        {
            var Review = await _context.Reviews.FindAsync(id);

            if (Review == null)
                return NotFound();

            return Ok(ToDto(Review));
        }

        // POST api/Reviews
        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> Create(ReviewDTO dto)
        {
            var Review = new Review();
            UpdateEntityFromDto(Review, dto);

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            var resultDto = ToDto(Review);

            // Returns 201 + Location header
            return CreatedAtAction(nameof(GetById), new { id = Review.Id }, resultDto);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReviewDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and body do not match.");

            var Review = await _context.Reviews.FindAsync(id);
            if (Review == null)
                return NotFound();

            UpdateEntityFromDto(Review, dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Reviews.AnyAsync(b => b.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Review = await _context.Reviews.FindAsync(id);
            if (Review == null)
                return NotFound();

            _context.Reviews.Remove(Review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
