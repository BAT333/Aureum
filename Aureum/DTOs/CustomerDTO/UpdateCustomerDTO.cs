using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs.CustomerDTO
{
    public record UpdateCustomerDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; }
    }
}
