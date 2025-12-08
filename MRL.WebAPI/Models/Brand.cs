using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRL.WebAPI.Models;

[Table("Brands", Schema = "MRL")]
public partial class Brand
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [InverseProperty("Brand")]
    public virtual ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
}
