namespace MRL.Shared.Contracts;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public CategoryDTO Clone()
    {
        return new CategoryDTO
        {
            Id = this.Id,
            Name = this.Name,
        };
    }

    public bool Equals(CategoryDTO other)
    {
        if (other == null) return false;

        return Id == other.Id &&
               Name == other.Name;
    }
}
