using CRM.Services.Helpers.Excel;

namespace CRM.Services
{
    /// <summary>
    /// Представляет интерфейс сервиса для работы с импортом файлов Excel
    /// </summary>
    public interface IExcelService
    {
        /// <summary>
        /// Представляет метод импорта (парсинга) файла Excel
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        ExcelParseResponse ExcelParse(IFormFile file);
    }
}
