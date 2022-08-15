namespace Blago.BLL.DTO
{
    public class MessageDto : Interfaces.IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Message { get; set; }
        public System.DateTime DateSend { get; set; }
    }
}
