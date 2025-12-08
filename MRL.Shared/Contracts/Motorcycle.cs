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
}
