using System.ComponentModel.DataAnnotations;

namespace Aureum.DTOs.CustomerDTO
{
    public record CreateCustomerDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; }
    }
}
