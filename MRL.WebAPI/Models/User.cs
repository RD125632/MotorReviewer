using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRL.WebAPI.Models;

[Table("Users", Schema = "MRLAccounts")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? ExperienceLevel { get; set; }

    [InverseProperty(nameof(Review.User))]
    public virtual ICollection<Review> Reviews { get; set; } = [];
}
