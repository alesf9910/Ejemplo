using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class StoreProduct
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StoreId { get; set; }

        public virtual Store Store { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image {  get; set; }
    }
}
