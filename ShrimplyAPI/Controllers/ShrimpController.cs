﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShrimplyAPI.CustomActionFilters;
using ShrimplyAPI.Models.Domain;
using ShrimplyAPI.Models.Dto;
using ShrimplyAPI.Repository;
using System.Net;

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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateShrimpRequestDto createShrimpRequestDto)
        {
            Shrimp shrimp = _mapper.Map<Shrimp>(createShrimpRequestDto);
            shrimp = await _shrimpRepository.CreateAsync(shrimp);

            ShrimpDto shrimpDto = _mapper.Map<ShrimpDto>(shrimp);

            return CreatedAtAction(nameof(GetById), new { id = shrimp.Id }, shrimp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000
            )
        {
            var shrimps = await _shrimpRepository.GetAllAsync(
                filterOn,
                filterQuery,
                sortBy,
                isAscending ?? true,
                pageNumber,
                pageSize);

            throw new Exception("this is new ex.");

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
        [ValidateModel]
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
