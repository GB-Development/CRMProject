using CRM.Jobs;
using CRM.Model.Entities;
using CRM.Services.Repositories;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IDealRepository<Deal> _dealRepository;
        /// <summary>
        /// Тестовый контроллер выполнения единичной задачи с применением Hangfire
        /// </summary>
        /// <param name="client">Клиент для обращения из Hangfire</param>
        /// <returns>Возвращает номер задачи</returns>
        [HttpPost]
        [Route("fire-and-forget")]
        public IActionResult FireAndForget(string client)
        {
            string jobId = BackgroundJob.Enqueue(() =>
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
        public IActionResult Delayed(string client)
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

            var serviceProvider = new FindOverdueTransactions(_dealRepository);
            RecurringJob.AddOrUpdate(() => serviceProvider.FindTransaction<List<Deal>>(), cron);

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
