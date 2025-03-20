using StoreProjectSystem_BackEnd.Enums;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Data.Dtos
{
    public class ReadEndProductDto
    {
        public string NameProduct { get; set; }
        public string TypeProduct { get; set; }
        public DateTime EnterInStore { get; set; }
        public double CostProduct { get; set; }
    }
}
