using Microsoft.AspNetCore.Identity;

namespace StoreProjectSystem_BackEnd.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string Gener { get; set; }
        public User() : base() { }
        public virtual ICollection<EndProduct> StoredProducts { get; set; }
    }
}
