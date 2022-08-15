namespace Blago.BLL.Interfaces
{
    public interface IEmailSender
    {
        string SendMessage(DTO.EmailEntity.EmailData md, string ownerRecepient, string attachment);
    }
}
