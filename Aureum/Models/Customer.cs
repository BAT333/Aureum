using System.ComponentModel.DataAnnotations;

namespace Aureum.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public long Id { get; private set; }

        [Required]
        [StringLength(100)]
        public string Name { get; private set; }
        public virtual IReadOnlyCollection<Account> Accounts {  get; private set; } 

        public Customer() { }

        internal void Update(string? newName)
        {
            if (!String.IsNullOrEmpty(newName) && !string.IsNullOrWhiteSpace(newName) && this.Name != newName) this.Name = newName;
        }
    }
}
