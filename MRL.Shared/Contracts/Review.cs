namespace MRL.Shared.Contracts;

public class ReviewDTO
{
    public int Id { get; set; }
    public int MotorcycleId { get; set; }
    public int UserId { get; set; }
    public DateTime ReviewDate { get; set; }
    public decimal HandlingScore { get; set; }
    public decimal EngineScore { get; set; }
    public decimal ComfortScore { get; set; }
    public decimal BrakesScore { get; set; }
    public decimal StabilityScore { get; set; }
    public decimal ValueScore { get; set; }
    public decimal? OverallScore { get; set; }
    public string? Comment { get; set; }

    public ReviewDTO Clone()
    {
        return new ReviewDTO
        {
            Id = this.Id,
            MotorcycleId = this.MotorcycleId,
            UserId = this.UserId,
            ReviewDate = this.ReviewDate,
            HandlingScore = this.HandlingScore,
            EngineScore = this.EngineScore,
            ComfortScore = this.ComfortScore,
            BrakesScore = this.BrakesScore,
            StabilityScore = this.StabilityScore,
            ValueScore = this.ValueScore,
            Comment = this.Comment
        };
    }

    public bool Equals(ReviewDTO other)
    {
        if (other == null) return false;

        return Id == other.Id &&
            MotorcycleId == other.MotorcycleId &&
            UserId == other.UserId &&
            ReviewDate == other.ReviewDate &&
            HandlingScore == other.HandlingScore &&
            EngineScore == other.EngineScore &&
            ComfortScore == other.ComfortScore &&
            BrakesScore == other.BrakesScore &&
            StabilityScore == other.StabilityScore &&
            ValueScore == other.ValueScore &&
            Comment == other.Comment;
    }
}
