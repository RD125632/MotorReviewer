namespace MRL.Shared.Contracts;

public class MotorcycleDTO
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string Model { get; set; } = null!;
    public int? Year { get; set; }
    public int? EngineCc { get; set; }
    public int? PowerHp { get; set; }

    public MotorcycleDTO Clone()
    {
        return new MotorcycleDTO
        {
            Id = this.Id,
            BrandId = this.BrandId,
            CategoryId = this.CategoryId,
            Model = this.Model,
            Year = this.Year,
            EngineCc = this.EngineCc,
            PowerHp = this.PowerHp
        };
    }

    public bool Equals(MotorcycleDTO other)
    {
        if (other == null) return false;

        return Id == other.Id &&
            BrandId == other.BrandId &&
            CategoryId == other.CategoryId &&
            Model == other.Model &&
            Year == other.Year &&
            EngineCc == other.EngineCc &&
            PowerHp == other.PowerHp;
    }
}
