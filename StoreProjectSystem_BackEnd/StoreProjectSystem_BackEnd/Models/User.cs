using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace StoreProjectSystem_BackEnd.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string Gener { get; set; }
        public bool Hired { get; set; }
        public User() : base() { }
        public string StoredProductsId { get; set; }
        public virtual ICollection<EndProduct> StoredProducts { get; set; }
    }
}
