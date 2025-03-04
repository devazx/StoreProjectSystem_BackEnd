using StoreProjectSystem_BackEnd.Enums;
using StoreProjectSystem_BackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class CreateEndProductDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameProduct { get; set; }
        [Required]
        public TypeProductEnum TypeProduct { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EnterInStore { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Currency)]
        public double CostProduct { get; set; }
        [Required]
        public string UserInputStoreID { get; set; }
    }
}
