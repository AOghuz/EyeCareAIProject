using EyeCareAIProject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
  
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "sametsafacan@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); // mailin kimden geldiği


            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo); // mailin kime gideceği
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody(); // Mailin içeriği
            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient Client = new SmtpClient();
            Client.Connect("smtp.gmail.com", 587, false);

            Client.Authenticate("sametsafacan@gmail.com", "qksb kfwd snsl gpyb"/*şifresi*/);

            Client.Send(mimeMessage);
            Client.Disconnect(true);
            return View();
        }
    }
}
