using CRM.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotificationServiceHangfireTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        /// <summary>
        /// Тестовый контроллер выполнения единичной задачи с применением Hangfire
        /// </summary>
        /// <param name="client">Клиент для обращения из Hangfire</param>
        /// <returns>Возвращает номер задачи</returns>
        [HttpPost]
        [Route("fire-and-forget")]
        public IActionResult FireAndForget(string client)
        {
            string jobId = BackgroundJob.Enqueue(()=>
                Console.WriteLine($"{client} привет это тестовый запуск"));
            return Ok($"Job ID: {jobId}");
        }

        /// <summary>
        /// Тестовый контроллер выполнения отложенной задачи с применением Hangfire
        /// </summary>
        /// <param name="client">Клиент для обращения из Hangfire</param>
        /// <returns>Возвращает номер задачи</returns>
        [HttpPost]
        [Route("delayed")]
        public IActionResult Delayed (string client)
        {
            string jobId = BackgroundJob.Schedule(() =>
            Console.WriteLine($"Сессия клиента: {client} - закрыта! тоже тест"), TimeSpan.FromSeconds(60));
            return Ok($"Job ID: {jobId}");
        }

        /// <summary>
        /// Тестовый контроллер выполнения периодической задачи с применением Hangfire
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("recurring")]
        public IActionResult Recurring()
        {
            string cron = "0 6-15 * * *";

            RecurringJob.AddOrUpdate("Run Find Overdue Transactions Job",
                () => ServiceProvider.GetService(serviceType).FindOverdueTransactions(), cron); ;
            return Ok();
        }

        /// <summary>
        /// Тестовый контроллер выполнения продолжительной задачи с применением Hangfire
        /// </summary>
        /// <param name="client">Клиент для обращения из Hangfire</param>
        /// <returns>Возвращает номер задачи</returns>
        [HttpPost]
        [Route("continuation")]
        public IActionResult Continuation(string client)
        {
            string jobId = BackgroundJob.Enqueue(() => Console.WriteLine($"Привет, "));
            BackgroundJob.ContinueWith(jobId, () => Console.WriteLine($"как дела {client}! Тест"));
            return Ok($"Job ID: {jobId}");
        }
    }
}
