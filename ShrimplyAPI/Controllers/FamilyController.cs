using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.CustomActionFilters;
using ShrimplyAPI.Data;
using ShrimplyAPI.Models.Domain;
using ShrimplyAPI.Models.Dto;
using ShrimplyAPI.Repository;
using System.Text.Json;

namespace ShrimplyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ShrimplyApiDbContext _shrimplyApiDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<FamilyController> _logger;

        public FamilyController(IFamilyRepository familyRepository,
            ShrimplyApiDbContext shrimplyApiDbContext,
            IMapper mapper,
            ILogger<FamilyController> logger)
        {
            _familyRepository = familyRepository;
            _shrimplyApiDbContext = shrimplyApiDbContext;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        //[Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogWarning("GetAll invoked");
            _logger.LogError("GetAll invoked");


            var families = await _familyRepository.GetAllAsync();

            List<FamilyDto> familiesDto = _mapper.Map<List<FamilyDto>>(families);

            _logger.LogInformation($"GetAll finished {JsonSerializer.Serialize(familiesDto)}");
            return Ok(familiesDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
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
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateFamilyRequestDto createFamilyRequestDto)
        {
            Family family = _mapper.Map<Family>(createFamilyRequestDto);

            family = await _familyRepository.CreateAsync(family);

            FamilyDto familyDto = _mapper.Map<FamilyDto>(family);
            return CreatedAtAction(nameof(GetById), new { id = family.Id }, familyDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
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
        //[Authorize(Roles = "Writer")]
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
