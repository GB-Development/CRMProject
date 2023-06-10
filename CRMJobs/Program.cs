using Hangfire;

namespace CRMJobs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jobId = BackgroundJob.Schedule(
                () => Console.WriteLine("Запуск отложенного задания!"),
                TimeSpan.FromDays(7));
        }
    }
}