using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRL.WebAPI.Models;

[Table("Motorcycles", Schema = "MRL")]
public partial class Motorcycle
{
    [Key]
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    [StringLength(100)]
    public string Model { get; set; } = null!;

    public int? Year { get; set; }

    [Column("EngineCC")]
    public int? EngineCc { get; set; }

    [Column("PowerHP")]
    public int? PowerHp { get; set; }

    [ForeignKey("BrandId")]
    [InverseProperty("Motorcycles")]
    public virtual Brand Brand { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Motorcycles")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Motorcycle")]
    public virtual ICollection<Review> Reviews { get; set; } = [];
}
