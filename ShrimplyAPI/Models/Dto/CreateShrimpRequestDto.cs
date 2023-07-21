using ShrimplyAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ShrimplyAPI.Models.Dto
{
    public class CreateShrimpRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid FamilyId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
