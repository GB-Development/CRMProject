namespace CRM.Services.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);

        void CreateCollection(List<T> items);
    }
}
