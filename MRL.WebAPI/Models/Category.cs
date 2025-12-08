using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRL.WebAPI.Models;

[Table("Categories", Schema = "MRL")]
public partial class Category
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
}
