using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShrimplyAPI.Dtos;
using ShrimplyAPI.Entities;

namespace ShrimplyAPI
{
    public static class Extensions
    {
        public static ShrimpDto AsDto(this Shrimp shrimp)
        {
            var shrimpDto = new ShrimpDto
            {
                Id = shrimp.Id,
                Name = shrimp.Name,
                Price = shrimp.Price,
                DateCreated = shrimp.DateCreated
            };
            return shrimpDto;
        }
    }
}