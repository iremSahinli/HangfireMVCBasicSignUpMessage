using Hangfire;
using Hangfire.Server;
using Microsoft.AspNetCore.Mvc;
using Hangfire.Console;

namespace MVC_RegistirationMessage_Hangfire.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //Hangfire RecurrringJob eklendi.
            RecurringJob.AddOrUpdate("SignUpReminderJob", () => SignUpReminder(), Cron.Minutely());
            return View();
        }

        public async Task SignUpReminder()
        {
            string message = DateTime.Now.ToString("HH:mm:ss") + "tarihinde hatırlatma yapıldı.";

            if (TempData != null)
            {
                TempData["SignUpMessage"] = message;
            }

            //Asenkron olarak çalıştırıldı.Kullanıcı arayüzündeki hangfire işlem saatleri log.txt dosyasına yazdırıldı.
            await System.IO.File.AppendAllTextAsync("log.txt", message + Environment.NewLine);


            Console.WriteLine(message);

        }
    }
}
