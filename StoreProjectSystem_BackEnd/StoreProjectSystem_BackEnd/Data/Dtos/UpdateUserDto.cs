namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ReadEndProductDto Products { get; set; }
    }
}
