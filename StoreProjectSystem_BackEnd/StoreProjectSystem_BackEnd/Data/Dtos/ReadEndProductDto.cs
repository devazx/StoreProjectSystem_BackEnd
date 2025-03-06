using StoreProjectSystem_BackEnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class ReadEndProductDto
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public TypeProductEnum TypeProduct { get; set; }
        public DateTime EnterInStore { get; set; }
        public double CostProduct { get; set; }
        public string UserInputStoreID { get; set; }
    }
}
