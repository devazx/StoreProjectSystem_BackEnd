using StoreProjectSystem_BackEnd.Enums;

namespace StoreProjectSystem_BackEnd.Models
{
    public class EndProduct
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public TypeProductEnum TypeProduct { get; set; }
        public double CostProduct { get; set; }
        public DateTime EnterInStore { get; set; } = DateTime.Now;
        public User UserInputStore { get; set; }
    }
}
