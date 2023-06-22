using CRM.Model.DTO;
using CRM.Services.Interfaces;

namespace CRM.Services.DTO
{
    /// <summary>
    /// Представляет сервис для работы с объектом <see cref="CompanyExcelDTO"/>
    /// </summary>
    public class CompanyExcelDTOService : ICompanyExcelDTOService
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CompanyExcelDTOService"/>
        /// </summary>
        public CompanyExcelDTOService() { }

        /// <summary>
        /// Представляет реализацию метода получения непустых значений свойств, которые являются базой для создания контактов компании
        /// </summary>
        /// <param name="type">Вид возвращаемых свойств: 1 - телефонные, 2 - почтовые</param>
        /// <param name="item">Экземпляр класса <see cref="CompanyExcelDTO"/></param>
        /// <returns></returns>
        public List<string?> GetContactProps(int type, CompanyExcelDTO item)
        {
            if (type == 1)
            {
                return item.GetType()
                    .GetProperties()
                    .Where(w => w.Name.Contains("PhoneNumber"))
                    .Select(s => s.GetValue(item) as string)
                    .Where(v => !string.IsNullOrEmpty(v))
                    .ToList();
            }

            if (type == 2)
            {
                return item.GetType()
                    .GetProperties()
                    .Where(w => w.Name.StartsWith("Email"))
                    .Select(s => s.GetValue(item) as string)
                    .Where(v => !string.IsNullOrEmpty(v))
                    .ToList();
            }

            return new List<string?>();
        }
    }
}
