using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string StorageProductsId { get; set; }
    }
}
