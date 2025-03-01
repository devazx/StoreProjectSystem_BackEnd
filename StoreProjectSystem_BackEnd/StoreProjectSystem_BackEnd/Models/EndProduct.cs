using StoreProjectSystem_BackEnd.Enums;

namespace StoreProjectSystem_BackEnd.Models
{
    public class EndProduct
    {
        public string NameProduct { get; set; }
        public TypeProductEnum TypeProduct { get; set; }
        public double CostProduct { get; set; }
    }
}
