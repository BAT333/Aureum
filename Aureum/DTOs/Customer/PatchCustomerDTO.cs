using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs.Customer
{
    public record PatchCustomerDTO
    {
        public string? Name { get; init; }
    }
}
