namespace Blago.BLL.DTO
{
    public class OrderDto : Interfaces.IModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TotalSum { get; set; }
        public System.DateTime OrderDate { get; set; }
    }
}
