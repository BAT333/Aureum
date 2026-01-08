using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aureum.Models
{
    public class Account
    {
        [Key]
        [Required]
        public long Id { get; private set; }

        public AccountType AccountType { get; private set; }

        [Required]
        [Range(0.01, (double)decimal.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "--")]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; private set; }

        [Required(ErrorMessage = "--")]
        public DateOnly DateOfPurchase { get; private set; }

        [Required]
        public long CustomerId { get; private set; }

        public virtual Customer Customer { get; private set; }
        //[Required]
        //public int InvoiceIdMonthYear { get; set; }

        //public virtual Invoice Invoice { get; set; }

        protected Account() { }

        public Account(long customerId, AccountType accountType, decimal price, string description, DateOnly dateOfPurchase)
        {
            CustomerId = customerId;
            AccountType = accountType;
            Price = price;
            Description = description;
            DateOfPurchase = dateOfPurchase;
        }
        public Account(AccountType accountType, decimal price, string description, DateOnly dateOfPurchase)
        {
            this.AccountType = accountType;
            this.Price = price;
            this.Description = description;
            this.DateOfPurchase = dateOfPurchase;
        }

        internal void UpdateAccount(AccountType? accountType, decimal? price, string? description, DateOnly? dateOfPurchase)
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

        }
    }
}
