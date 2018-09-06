using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortfolio.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WebPortfolio.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        public ActionResult Send()
        {
            return PartialView("SendForm");
        }

        [HttpPost]
        public ActionResult Send(SendModel item)
        {
            if (item.Name != null && item.Text != null)
            {
                EmailSettings sett = new EmailSettings();
                EmailOrderProcessor functionality = new EmailOrderProcessor(sett);
                functionality.ProcessOrder(item);
                return PartialView("Ok");
            }
            else return PartialView("NotOk");
        }
	}

    public class EmailSettings
    {
        public string MailToAddress = "ermakovzen@gmail.com";
        public string MailFromAddress = "mail@bo-zhu.by";
        public bool UseSsl = true;
        public string Username = "mail@bo-zhu.by";
        public string Password = "zzzzzzzzzz";
        public string ServerName = "mail.bo-zhu.by";
        public int ServerPort = 465;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\store_emails";
    }

    public class EmailOrderProcessor 
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(SendModel item)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                
                body.AppendFormat("Общая стоимость: {0:c}", 444)
                    
                    .AppendLine(item.Name)
                    .AppendLine(item.Email ?? "")
                    .AppendLine(item.Telefone ?? "")
                    .AppendLine(item.Text)
                    
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,	// От кого
                                       emailSettings.MailToAddress,		// Кому
                                       "Поступил заказ с сайта!",		// Тема
                                       body.ToString()); 				// Тело письма

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}