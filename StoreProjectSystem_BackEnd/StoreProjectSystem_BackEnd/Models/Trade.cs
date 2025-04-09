namespace StoreProjectSystem_BackEnd.Models
{
    public class Trade
    {
        public int ProductId { get; set; }
        public EndProduct EndProduct { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
