using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShrimplyAPI.Dtos
{
    public class UpdateShrimpDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
    }
}