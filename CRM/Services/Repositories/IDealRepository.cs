using CRM.Model.Entities;

namespace CRM.Services.Repositories
{
    /// <summary>
    /// Представляет интерфейс репозитория для работы с объектами типа <see cref="Deal"/>
    /// </summary>
    public interface IDealRepository : IRepository<Deal>
    {
        Task<List<Deal>> GetAllAsync();
        Task<Deal> GetByIdAsync(int id);
        Task<List<Deal>> GetAllByIdManagerAsync(string id);
    }
}
