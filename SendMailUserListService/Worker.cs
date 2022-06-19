using Hangfire;
using System.Net.Mail;

namespace SendMailUserListService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //mail için gerekli nesneleri tanýmlýyoruz.
                MailMessage MyMail = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential("Bedirhan_98@outlook.com", "secret");
                istemci.Port = 587;
                istemci.Host = "smtp.live.com";
                istemci.EnableSsl = true;
                MyMail.To.Add("recipient_mail@gmail.com");
                MyMail.From = new MailAddress("Bedirhan_98@outlook.com");
                //Mailin içeriklerini dolduruyoruz.
                MyMail.Subject = "abcd";
                MyMail.Body = "asdf";
                Attachment attachment;
                attachment = new Attachment($"E:\\DotNetWork\\UserLists{DateTime.Now.ToString("yyyy_MM_dd_HHmm")}.xlsx");
                MyMail.Attachments.Add(attachment);

                RecurringJob.AddOrUpdate(() => istemci.Send(MyMail), "0 35 7 ? * MON,TUE,WED,THU,FRI *");

            }
        }
    }
}