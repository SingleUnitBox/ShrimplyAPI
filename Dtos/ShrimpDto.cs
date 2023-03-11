using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShrimplyAPI.Dtos
{
    public record ShrimpDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset DateCreated { get; init; }
    }
}