using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShrimplyAPI.Dtos;
using ShrimplyAPI.Entities;
using ShrimplyAPI.Repositories;

namespace ShrimplyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShrimpsController : ControllerBase
    {
        private readonly IShrimpsRepository _shrimpsRepository;
        public ShrimpsController(IShrimpsRepository shrimpsRepository)
        {
            _shrimpsRepository = shrimpsRepository;
        }

        [HttpGet]
        public IEnumerable<ShrimpDto> GetShrimps()
        {
            var items = _shrimpsRepository.GetShrimps().Select(shrimp => shrimp.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ShrimpDto> GetShrimp(Guid id)
        {
            var shrimp = _shrimpsRepository.GetShrimp(id);

            if (shrimp == null)
            {
                return NotFound();
            }
            return Ok(shrimp.AsDto());
        }

        [HttpPost]
        public ActionResult<ShrimpDto> CreateShrimp(CreateShrimpDto shrimpDto)
        {
            var shrimp = new Shrimp
            {
                Id = Guid.NewGuid(),
                Name = shrimpDto.Name,
                Price = shrimpDto.Price,
                DateCreated = DateTimeOffset.UtcNow,
            };
            _shrimpsRepository.CreateShrimp(shrimp);
            return CreatedAtAction(nameof(GetShrimp), new { id = shrimp.Id }, shrimp.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateShrimp(Guid id, UpdateShrimpDto shrimpDto)
        {
            var existingShrimp = _shrimpsRepository.GetShrimp(id);
            if (existingShrimp == null)
            {
                return NotFound();
            }
            var shrimp = existingShrimp with
            {
                Name = shrimpDto.Name,
                Price = shrimpDto.Price
            };

            _shrimpsRepository.UpdateShrimp(shrimp);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteShrimp(Guid id)
        {
            var existingShrimp = _shrimpsRepository.GetShrimp(id);
            if (existingShrimp == null)
            {
                return NotFound();
            }
            _shrimpsRepository.DeleteShrimp(id);
            return NoContent();
        }
    }
}