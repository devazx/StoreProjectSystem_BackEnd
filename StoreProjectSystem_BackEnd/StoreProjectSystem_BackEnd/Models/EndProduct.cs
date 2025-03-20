using StoreProjectSystem_BackEnd.Enums;

namespace StoreProjectSystem_BackEnd.Models
{
    public class EndProduct
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameProduct { get; set; }
        public TypeProductEnum TypeProduct { get; set; }
        public double CostProduct { get; set; }
        public DateTime EnterInStore { get; set; } = DateTime.Now;
        public string? UserInputStoreID { get; set; }
        public virtual User UserInputStore { get; set; }
        
    }
}
