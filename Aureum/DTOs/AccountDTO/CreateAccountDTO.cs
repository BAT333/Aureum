using Aureum.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aureum.DTOs.AccountDTO
{
    public record CreateAccountDTO
    {
        public AccountType AccountType { get; init; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; init; }
        [Required(ErrorMessage = "--")]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; init; }
        [Required(ErrorMessage = "--")]
        public DateOnly DateOfPurchase { get; init; }
        [Required(ErrorMessage = "--")]
        public long CustomerId { get; init;  }
    }
}
