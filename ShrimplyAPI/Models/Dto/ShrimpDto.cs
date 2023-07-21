using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Models.Dto
{
    public class ShrimpDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Family Family { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
