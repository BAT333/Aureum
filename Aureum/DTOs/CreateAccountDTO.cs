using Aureum.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aureum.DTOs
{
    public record CreateAccountDTO
    {
        public AccountType AccountType { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "--")]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }
        [Required(ErrorMessage = "--")]
        public DateOnly DateOfPurchase { get; set; }
    }
}
