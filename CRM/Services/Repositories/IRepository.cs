namespace CRM.Services.Repositories
{
    /// <summary>
    /// Представляет общий репозиторий для работы с генерализованными объектами
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity, TKey> 
        where TEntity : class 
        where TKey : struct
    {
        /// <summary>
        /// Представляет метод создания и сохранения одиночного объекта
        /// </summary>
        /// <param name="item"></param>
        Task<TKey> CreateAsync(TEntity item);

        /// <summary>
        /// Представляет метод создания и сохранения коллекции объектов
        /// </summary>
        /// <param name="items"></param>
        Task CreateCollectionAsync(List<TEntity> items);

        /// <summary>
        /// Представляет метод получение объекта из БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetByIdAsync(TKey id);

        /// <summary>
        /// Представляет метод получении колекции объектов из БД
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Представляет метод обновления объекта в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает обновленный объект</returns>
        Task<bool> UpdateAsync(TEntity item);

        /// <summary>
        /// Представляет метод удаления объекта из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity item);
    }
}
