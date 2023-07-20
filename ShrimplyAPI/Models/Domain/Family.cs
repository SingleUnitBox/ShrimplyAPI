namespace ShrimplyAPI.Models.Domain;

public class Family
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string? ImageUrl { get; set; }
}
