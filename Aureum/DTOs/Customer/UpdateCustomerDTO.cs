using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs.Customer
{
    public record UpdateCustomerDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; }
    }
}
