namespace CRM.Services.Helpers.Excel
{
    /// <summary>
    /// Представляет класс, хранящий информацию о результате импорта (парсинга) файла Excel
    /// </summary>
    public class ExcelParseResponse
    {
        /// <summary>
        /// Получает признак успешного/неуспешного результата импорта (парсинга) файла Excel
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Получает или задает код статуса импорта файла Excel
        /// </summary>
        public ParseStatusCodeType StatusCode { get; set; }

        /// <summary>
        /// Получает или задает текст результата импорта файла Excel
        /// </summary>
        public string? ParseResultMessage { get; set; }
    }
}
