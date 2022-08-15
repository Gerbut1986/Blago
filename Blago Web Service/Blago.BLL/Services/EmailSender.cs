namespace Blago.BLL.Services
{
    using DTO.EmailEntity;
    using System.Net.Mail;
    using System.Net.Mime;
    using Blago.BLL.Interfaces;
    using Blago.BLL.PartialModels.Email;

    public class EmailSender : IEmailSender
    {
        private readonly EmailData data;

        public EmailSender(EmailData data, string htmlBody = null) { this.data = data; }

        public string SendMessage(EmailData md, string attachFile = null, string ownerRecepient = null)
        {
            try
            {
                var recepient = ownerRecepient != null ? ownerRecepient : "andriygerbut@gmail.com"; 
                MailAddress from = new MailAddress(data.Email, "Blago");
                MailAddress to = new MailAddress(recepient); // email to admin
                MailMessage m = new MailMessage(from, to); 
                m.IsBodyHtml = true;
                m.Subject = data.Title + " - " + data.SendingDate;
                m.IsBodyHtml = true;
                m.Body = md.Body;
                if (attachFile != null)
                    m.Attachments.Add(Attach(attachFile));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential(Credential.Mail, Credential.Pass);
                smtp.EnableSsl = true;
                smtp.Send(m);
                return "Сообщение(я) успешно доставлено!";
            }
            catch(System.Exception ex)
            {
                return ex.Message;// + " | " + ex.StackTrace;
            }
        }

        private Attachment Attach(string file)
        {
            var attach = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = attach.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this email message.
            return attach;
        }
    }
}
