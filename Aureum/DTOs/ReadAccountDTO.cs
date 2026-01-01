using Aureum.Models;
using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs
{
    public record ReadAccountDTO
    {
        public AccountType AccountType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateOnly DateOfPurchase { get; set; }
    }
}
