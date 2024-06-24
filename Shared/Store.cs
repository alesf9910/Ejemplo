using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
    [Index("Name", IsUnique = true)]
    public class Store
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; } 

        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
