using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace NotificationServiceHangfireTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        [Route("fire-and-forget")]
        public IActionResult FireAndForget(string client)
        {
            string jobId = BackgroundJob.Enqueue(()=>
                Console.WriteLine($"{client} привет это тестовый запуск"));
            return Ok($"Job ID: {jobId}");
        }

        [HttpPost]
        [Route("delayed")]
        public IActionResult Delayed (string client)
        {
            string jobId = BackgroundJob.Schedule(() =>
            Console.WriteLine($"Сессия клиента: {client} - закрыта! тоже тест"), TimeSpan.FromSeconds(60));
            return Ok($"Job ID: {jobId}");
        }
        [HttpPost]
        [Route("recurring")]
        public IActionResult Recurring()
        {
            RecurringJob.AddOrUpdate("Run Find Overdue Transactions Job", () => Console.WriteLine("Тут будет сообщение!"), "0 6-15 * * *"); ;
            return Ok();
        }
    }
}
