namespace Blago.DAL.Entities
{
    public class Withdrawal
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public System.DateTime DateWithdraw { get; set; }
        public string NumberCard { get; set; }
        public string Amount { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
