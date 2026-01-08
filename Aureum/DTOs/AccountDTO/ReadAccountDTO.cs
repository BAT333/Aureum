using Aureum.DTOs.CustomerDTO;
using Aureum.Models;

namespace Aureum.DTOs.AccountDTO
{
    public record ReadAccountDTO
    {
        public AccountType AccountType { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; }
        public DateOnly DateOfPurchase { get; init; }

        public ReadCustomerDTO Customer { get; init; }
    }
}
