namespace ShrimplyAPI.Models.Domain;

public class Shrimp
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid FamilyId { get; set; }
    public Guid DifficultyId { get; set; }
    public Family Family { get; set; }
    public Difficulty Difficulty { get; set; }
}
