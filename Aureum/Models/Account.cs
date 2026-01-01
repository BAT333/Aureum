using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aureum.Models
{
    public class Account
    {
        [Key]
        [Required]
        public long Id { get; private set; }
        public AccountType AccountType { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "--")]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }
        [Required(ErrorMessage = "--")]
        public DateOnly DateOfPurchase { get; set; }

        public Account() { }
        public Account(AccountType accountType, decimal price, string description, DateOnly dateOfPurchase)
        {
            this.AccountType = accountType;
            this.Price = price;
            this.Description = description;
            this.DateOfPurchase = dateOfPurchase;
        }
        public Account(long id, AccountType accountType, decimal price, string description, DateOnly dateOfPurchase)
        {
            this.Id = id;
            this.AccountType = accountType;
            this.Price = price;
            this.Description = description;
            this.DateOfPurchase = dateOfPurchase;
        }

        public Account UpdateAccount(AccountType? accountType, decimal? price, string? description, DateOnly? dateOfPurchase)
        {
            if (accountType.HasValue)
            {
                this.AccountType = accountType.Value;
            }
            if (price.HasValue)
            {
                this.Price = price.Value;
            }
            if (description != null)
            {
                this.Description = description;
            }
            if (dateOfPurchase.HasValue)
            {
                this.DateOfPurchase = dateOfPurchase.Value;

            }

            return this;
        }
    }
}
