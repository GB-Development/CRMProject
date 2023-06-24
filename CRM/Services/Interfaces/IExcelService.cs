using CRM.Services.Helpers.Excel;

namespace CRM.Services.Interfaces
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
        Task<ExcelParseResponse> ExcelParse(IFormFile file);
    }
}
