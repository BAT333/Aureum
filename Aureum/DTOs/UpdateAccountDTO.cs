using Aureum.Models;
using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs
{
    public record UpdateAccountDTO
    {
        public AccountType? AccountType { get; init; }
        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; init; }
        [StringLength(200, MinimumLength = 3)]
        public string? Description { get; init; }
        public DateOnly? DateOfPurchase { get; init; }
    }
}
