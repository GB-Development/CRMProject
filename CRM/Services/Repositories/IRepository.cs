namespace CRM.Services.Repositories
{
    /// <summary>
    /// Представляет общий репозиторий для работы с генерализованными объектами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);
    }
}
