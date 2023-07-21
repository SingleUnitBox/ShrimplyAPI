using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShrimplyAPI.Models.Domain;
using ShrimplyAPI.Models.Dto;
using ShrimplyAPI.Repository;

namespace ShrimplyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShrimpController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShrimpRepository _shrimpRepository;

        public ShrimpController(IMapper mapper,
            IShrimpRepository shrimpRepository)
        {
            _mapper = mapper;
            _shrimpRepository = shrimpRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShrimpRequestDto createShrimpRequestDto)
        {
            Shrimp shrimp = _mapper.Map<Shrimp>(createShrimpRequestDto);
            shrimp = await _shrimpRepository.CreateAsync(shrimp);

            ShrimpDto shrimpDto = _mapper.Map<ShrimpDto>(shrimp);

            return Ok(shrimpDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shrimps = await _shrimpRepository.GetAllAsync();
            if (shrimps == null)
            {
                return NoContent();
            }
            List<ShrimpDto> shrimpsDto = _mapper.Map<List<ShrimpDto>>(shrimps);
            return Ok(shrimpsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var shrimp = await _shrimpRepository.GetByIdAsync(id);
            if (shrimp == null)
            {
                return NotFound();
            }
            ShrimpDto shrimpDto = _mapper.Map<ShrimpDto>(shrimp);
            return Ok(shrimpDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EditShrimpRequestDto editShrimpRequestDto)
        {
            var shrimp = _mapper.Map<Shrimp>(editShrimpRequestDto);
            shrimp = await _shrimpRepository.UpdateAsync(id, shrimp);
            if (shrimp == null)
            {
                return NotFound();
            }
            ShrimpDto shrimpDto = _mapper.Map<ShrimpDto>(shrimp);
            return Ok(shrimpDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var shrimp = await _shrimpRepository.DeleteAsync(id);
            if (shrimp == null)
            {
                return NotFound();
            }
            ShrimpDto shrimpDto = _mapper.Map<ShrimpDto>(shrimp);
            return Ok(shrimpDto);
        }
    }
}
