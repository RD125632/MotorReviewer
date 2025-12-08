using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRL.WebAPI.Models;

[Table("Reviews", Schema = "MRL")]
public partial class Review
{
    [Key]
    public int Id { get; set; }

    public int MotorcycleId { get; set; }

    public int UserId { get; set; }

    public DateTime ReviewDate { get; set; }

    public decimal HandlingScore { get; set; }

    public decimal SpeedScore { get; set; }

    public decimal ComfortScore { get; set; }

    public decimal BrakesScore { get; set; }

    public decimal StabilityScore { get; set; }

    public decimal ValueScore { get; set; }

    [Column(TypeName = "numeric(10, 6)")]
    public decimal? OverallScore { get; set; }

    public string? Comment { get; set; }

    [ForeignKey("MotorcycleId")]
    [InverseProperty("Reviews")]
    public virtual Motorcycle Motorcycle { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User User { get; set; } = null!;
}
