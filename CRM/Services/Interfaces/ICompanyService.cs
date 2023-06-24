using CRM.Model.DTO;
using CRM.Data.Entities;

namespace CRM.Services.Interfaces
{
    /// <summary>
    /// Представляет интерфейс сервиса для работы с объектами типа <see cref="Company"/>
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Представляет метод создания сущностей (компаний и контактов) при импорте (парсинге) файла Excel
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        List<Company>? CreateEntities(List<CompanyExcelDTO>? dtos);
    }
}
