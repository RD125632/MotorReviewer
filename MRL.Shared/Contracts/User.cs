namespace MRL.Shared.Contracts;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ExperienceLevel { get; set; }

    public UserDTO Clone()
    {
        return new UserDTO
        {
            Id = this.Id,
            Name = this.Name,
            ExperienceLevel = this.ExperienceLevel,
        };
    }

    public bool Equals(UserDTO other)
    {
        if (other == null) return false;

        return Id == other.Id &&
               Name == other.Name &&
               ExperienceLevel == other.ExperienceLevel;
    }
}
