namespace CRM.Services.Helpers.Excel
{
    /// <summary>
    /// Представляет методы и классы, хранящие данные об ошибках/результатах импорта файлов Excel
    /// </summary>
    public class ExcelResult
    {
        /// <summary>
        /// Представляет класс, хранящий локализованные наименования типов ошибок/результатов импорта файлов Excel
        /// </summary>
        public static class ExcelParseMessage
        {
            public const string FileEmpty = "Отсутствует файл для импорта.";
            public const string ImportFail = "Импорт файла не был выполнен, имеются ошибки.";
            public const string ImportSuccess = "Импорт файла выполнен успешно. Данные сохранены в БД.";
        }
    }
}
