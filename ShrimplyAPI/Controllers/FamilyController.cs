using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.Data;
using ShrimplyAPI.Models.Domain;
using ShrimplyAPI.Models.Dto;
using ShrimplyAPI.Repository;

namespace ShrimplyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ShrimplyApiDbContext _shrimplyApiDbContext;

        public FamilyController(IFamilyRepository familyRepository,
            ShrimplyApiDbContext shrimplyApiDbContext)
        {
            _familyRepository = familyRepository;
            _shrimplyApiDbContext = shrimplyApiDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var families = await _familyRepository.GetAllAsync();

            List<FamilyDto> familiesDto = new();
            foreach (var family in families)
            {
                FamilyDto familyDto = new()
                {
                    Id = family.Id,
                    Name = family.Name,
                    Code = family.Code,
                    ImageUrl = family.ImageUrl,
                };
                familiesDto.Add(familyDto);
            }

            return Ok(familiesDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null)
            {
                return NotFound();
            }
            FamilyDto familyDto = new()
            {
                Id = family.Id,
                Name = family.Name,
                Code = family.Code,
                ImageUrl = family.ImageUrl,
            };
            return Ok(familyDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFamilyRequestDto createFamilyRequestDto)
        {
            Family family = new()
            {
                Name = createFamilyRequestDto.Name,
                Code = createFamilyRequestDto.Code,
                ImageUrl = createFamilyRequestDto.ImageUrl,
            };

            family = await _familyRepository.CreateAsync(family);

            FamilyDto familyDto = new()
            {
                Id = family.Id,
                Name = family.Name,
                Code = family.Code,
                ImageUrl = family.ImageUrl,
            };
            return CreatedAtAction(nameof(GetById), new { id = family.Id }, familyDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Edit([FromBody] EditFamilyRequestDto editFamilyRequestDto, [FromRoute] Guid id)
        {
            Family family = new()
            {
                Name = editFamilyRequestDto.Name,
                Code = editFamilyRequestDto.Code,
                ImageUrl = editFamilyRequestDto.ImageUrl,
            };
            family = await _familyRepository.UpdateAsync(family, id);

            if (family == null)
            {
                return NotFound();
            }

            FamilyDto familyDto = new()
            {
                Id =family.Id,
                Name = family.Name,
                Code = family.Code,
                ImageUrl = family.ImageUrl,
            };

            return Ok(familyDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var family = await _familyRepository.DeleteAsync(id);
            if (family == null)
            {
                return NotFound();
            }

            FamilyDto familyDto = new()
            {
                Id = family.Id,
                Name = family.Name,
                Code = family.Code,
                ImageUrl = family.ImageUrl,
            };
            return Ok(familyDto);
        }
    }
}
