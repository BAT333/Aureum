using Aureum.Models;
using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs
{
    public record UpdateAccountDTO
    {
        [Required]
        public AccountType AccountType { get; init; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; init; }
        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string Description { get; init; }
        [Required]
        public DateOnly DateOfPurchase { get; init; }
    }
}
