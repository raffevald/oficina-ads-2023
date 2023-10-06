

using System.Net;
using System.Net.Mail;

public class EmailServiceImpl {



    public Boolean SendMail() {

        try {
            MailMessage mailMessage = new MailMessage();

            var smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 60 * 60;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("oficina-ads@outlook.com", "UmaSenhaMuitoForte@Oficina");
            
            mailMessage.From = new MailAddress("rafaelevaldsilva@gmail.com", "Testes");
            mailMessage.Body = "Testando o envio de email";
            mailMessage.Subject = "Testes";
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.To.Add("rafaelevaldsilva@gmail.com");

            smtpClient.Send(mailMessage);

            return true;
            
        } catch {
            return false;
        }
    }
}