using CRM.Model.DTO;

namespace CRM.Services.Interfaces
{
    /// <summary>
    /// Представляет интерфейс сервиса для работы с объектами типа <see cref="CompanyExcelDTO"/>
    /// </summary>
    public interface ICompanyExcelDTOService
    {
        /// <summary>
        /// Представляет метод, получающий непустые значения свойств, которые являются базой для создания контактов компании
        /// </summary>
        /// <param name="type">Вид возвращаемых свойств: 1 - телефонные, 2 - почтовые</param>
        /// <param name="item">Экземпляр класса <see cref="CompanyExcelDTO"/></param>
        /// <returns></returns>
        List<string?> GetContactProps(int type, CompanyExcelDTO item);
    }
}
