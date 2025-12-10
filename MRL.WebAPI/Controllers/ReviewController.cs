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
            EngineScore = Review.EngineScore,
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
            entity.EngineScore = dto.EngineScore;
            entity.ComfortScore = dto.ComfortScore;
            entity.BrakesScore = dto.BrakesScore;
            entity.StabilityScore = dto.StabilityScore;
            entity.ValueScore = dto.ValueScore;
            entity.OverallScore = dto.OverallScore;
            entity.Comment = dto.Comment;
        }

        #region HTTP Calls

        // GET: api/Review?....
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews(
            [FromQuery] int? motorcycleId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to)
        {
            // Start with all reviews
            IQueryable<Review> query = _context.Reviews;

            if (motorcycleId.HasValue) query = query.Where(r => r.MotorcycleId == motorcycleId.Value);
            if (from.HasValue) query = query.Where(r => r.ReviewDate >= from.Value);
            if (to.HasValue) query = query.Where(r => r.ReviewDate <= to.Value);

            var reviews = await query
                .OrderBy(r => r.ReviewDate)
                .Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    MotorcycleId = r.MotorcycleId,
                    UserId = r.UserId,
                    ReviewDate = r.ReviewDate,
                    HandlingScore = r.HandlingScore,
                    EngineScore = r.EngineScore,
                    ComfortScore = r.ComfortScore,
                    BrakesScore = r.BrakesScore,
                    StabilityScore = r.StabilityScore,
                    ValueScore = r.ValueScore,
                    Comment = r.Comment
                })
                .ToListAsync();

            return Ok(reviews);
        }


        // GET api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetById(int id)
        {
            var Review = await _context.Reviews.FindAsync(id);

            if (Review == null)
                return NotFound();

            return Ok(ToDto(Review));
        }

        // POST api/Review
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

        // PUT: api/Review/5
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

        // DELETE: api/Review/5
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
