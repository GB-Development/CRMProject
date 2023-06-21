using Abp.Domain.Repositories;
using CRM.Model.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRM.Services.Repositories
{
    public interface IDealRepository : IRepository<Company>
    {

    }
}
