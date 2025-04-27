using StoreProjectSystem_BackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class CreateUserDto
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Hired { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string Repassword { get; set; }
        public string StorageProductsId { get; set; }
    }
}
