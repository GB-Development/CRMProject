namespace CRM.Services.Repositories
{
    /// <summary>
    /// Представляет общий контракт для работы с репозиториями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task<int> CreateAsync(T item);

        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(T item);

		Task<List<T>> GetAllAsync();

		Task<T?> GetByIDAsync(int id);

		Task<bool> CreateCollectionAsync(List<T> items);
	}
}
