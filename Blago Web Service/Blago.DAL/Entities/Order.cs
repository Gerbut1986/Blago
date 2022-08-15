namespace Blago.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TotalSum { get; set; }
        public System.DateTime OrderDate { get; set; }
    }
}
