using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShrimplyAPI.Entities;
using ShrimplyAPI.Repositories;

namespace ShrimplyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShrimpsController : ControllerBase
    {
        private readonly IInMemShrimpsRepository _shrimpsRepository;
        public ShrimpsController(IInMemShrimpsRepository shrimpsRepository)
        {
            _shrimpsRepository = shrimpsRepository;       
        }

        [HttpGet]
        public IEnumerable<Shrimp> GetShrimps()
        {
            var items = _shrimpsRepository.GetShrimps();  
            return items;          
        }

        [HttpGet("{id}")]
        public ActionResult<Shrimp> GetShrimp(Guid id)
        {
            var shrimp = _shrimpsRepository.GetShrimp(id);

            if (shrimp == null)
            {
                return NotFound();
            }
            return Ok(shrimp);
        }
    }
}