using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Category { get; set; }

        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
