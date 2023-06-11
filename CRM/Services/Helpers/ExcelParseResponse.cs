namespace CRM.Services.Helpers
{
    public class ExcelParseResponse
    {
        public const string FileEmpty = "Отсутствует файл для импорта.";
        public const string ImportFail = "Импорт файл не был выполнен, имеются ошибки.";

        /// <summary>
        /// 
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StatusCodeType StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ErrorMessage { get; set; }
    }

    public enum StatusCodeType
    {
        Fail = 0,
        Success = 1,
    }
}
