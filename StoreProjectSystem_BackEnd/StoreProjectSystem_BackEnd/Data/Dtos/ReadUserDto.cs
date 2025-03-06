namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class ReadUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<ReadEndProductDto> Products { get; set; }
    }
}
