using System;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string mailSend = "";
            Console.WriteLine("Dese enviar correo?");
            mailSend = Console.ReadLine();
            //
            if (mailSend == "si")
            {
                String server = "smtp.gmail.com"; //server smtp
                int port = 587; //default port gmail smtp
                string gmailUser = "examplegmail@gmail.com"; //your gmail
                string gmailPass = "mola123MOLA";

                //receiver gmail
                string gmailUserReceiver = "putAngmailToSend@gmail.com";

                MimeMessage msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("testMSG", gmailUser));
                msg.To.Add(new MailboxAddress("receiver", gmailUserReceiver));
                msg.Subject = "This is an example, testing if this works";

                BodyBuilder bodyMessage = new BodyBuilder();
                bodyMessage.HtmlBody = "This is an msg with html format you can use <b> lorem ipsum </b>";
                msg.Body = bodyMessage.ToMessageBody();

                SmtpClient clientSmtp = new SmtpClient();
                clientSmtp.CheckCertificateRevocation = false;
                clientSmtp.Connect(server, port, MailKit.Security.SecureSocketOptions.StartTls);

                clientSmtp.Authenticate(gmailUser, gmailPass);
                clientSmtp.Send(msg);//send message to receiver
                clientSmtp.Disconnect(true);//close server connection

                }



            }


        }


    }
}
