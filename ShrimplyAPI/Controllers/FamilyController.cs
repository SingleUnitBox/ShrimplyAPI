using AutoMapper;
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
        private readonly IMapper _mapper;

        public FamilyController(IFamilyRepository familyRepository,
            ShrimplyApiDbContext shrimplyApiDbContext,
            IMapper mapper)
        {
            _familyRepository = familyRepository;
            _shrimplyApiDbContext = shrimplyApiDbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var families = await _familyRepository.GetAllAsync();

            List<FamilyDto> familiesDto = _mapper.Map<List<FamilyDto>>(families);
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
            FamilyDto familyDto= _mapper.Map<FamilyDto>(family);
            return Ok(familyDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFamilyRequestDto createFamilyRequestDto)
        {
            Family family = _mapper.Map<Family>(createFamilyRequestDto);

            family = await _familyRepository.CreateAsync(family);

            FamilyDto familyDto = _mapper.Map<FamilyDto>(family);
            return CreatedAtAction(nameof(GetById), new { id = family.Id }, familyDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Edit([FromBody] EditFamilyRequestDto editFamilyRequestDto, [FromRoute] Guid id)
        {
            Family family = _mapper.Map<Family>(editFamilyRequestDto);
            family = await _familyRepository.UpdateAsync(family, id);

            if (family == null)
            {
                return NotFound();
            }

            FamilyDto familyDto = _mapper.Map<FamilyDto>(family);

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

            FamilyDto familyDto = _mapper.Map<FamilyDto>(family);
            return Ok(familyDto);
        }
    }
}
