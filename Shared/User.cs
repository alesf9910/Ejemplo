using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class User : IdentityUser
    {
        public virtual ICollection<Store> Stores { get; set; }
    }
}
