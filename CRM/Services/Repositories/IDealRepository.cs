using CRM.Model.Entities;

namespace CRM.Services.Repositories
{
    public interface IDealRepository <T> : IRepository<Deal>
    {
        /// <summary>
        /// Представляет метод чтения коллекции объектов
        /// </summary>
        /// <param name="items"></param>
        void ReadCollection(List<Deal> items);
    }
}
