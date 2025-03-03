using StoreProjectSystem_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class CreateEndProductDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public TypeProductEnum TypeProduct { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StorageDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
    }
}
