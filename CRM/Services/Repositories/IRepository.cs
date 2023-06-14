namespace CRM.Services.Repositories
{
    /// <summary>
    /// Представляет общий репозиторий для работы с генерализованными объектами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Представляет метод создания и сохранения одиночного объекта
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Представляет метод создания и сохранения коллекции объектов
        /// </summary>
        /// <param name="items"></param>
        void CreateCollection(List<T> items);
    }
}
