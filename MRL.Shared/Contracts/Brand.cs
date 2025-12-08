namespace MRL.Shared.Contracts;

public class BrandDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public BrandDTO Clone()
    {
        return new BrandDTO
        {
            Id = this.Id,
            Name = this.Name,
        };
    }

    public bool Equals(BrandDTO other)
    {
        if (other == null) return false;

        return Id == other.Id &&
               Name == other.Name;
    }
}
