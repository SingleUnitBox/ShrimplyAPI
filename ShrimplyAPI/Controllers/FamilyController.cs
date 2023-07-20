using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.Data;
using ShrimplyAPI.Models.Domain;
using ShrimplyAPI.Models.Dto;

namespace ShrimplyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly ShrimplyApiDbContext _shrimplyApiDbContext;

        public FamilyController(ShrimplyApiDbContext shrimplyApiDbContext)
        {
            _shrimplyApiDbContext = shrimplyApiDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var families = await _shrimplyApiDbContext.Families.ToListAsync();

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
            var family = await _shrimplyApiDbContext.Families.FirstOrDefaultAsync(f => f.Id == id);
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

            await _shrimplyApiDbContext.Families.AddAsync(family);
            await _shrimplyApiDbContext.SaveChangesAsync();

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
            var family = await _shrimplyApiDbContext.Families.FirstOrDefaultAsync(x => x.Id == id);
            if (family == null)
            {
                return NotFound();
            }

            family.Name = editFamilyRequestDto.Name;
            family.Code = editFamilyRequestDto.Code;
            family.ImageUrl = editFamilyRequestDto.ImageUrl;
            await _shrimplyApiDbContext.SaveChangesAsync();

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
            var family = await _shrimplyApiDbContext.Families.FirstOrDefaultAsync(x => x.Id == id);
            if (family == null)
            {
                return NotFound();
            }
            _shrimplyApiDbContext.Families.Remove(family);
            await _shrimplyApiDbContext.SaveChangesAsync();

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
