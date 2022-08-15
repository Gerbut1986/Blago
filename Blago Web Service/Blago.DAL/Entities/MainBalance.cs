namespace Blago.DAL.Entities
{
    public class MainBalance
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Amount { get; set; }
        public int UserId { get; set; }
    }
}
