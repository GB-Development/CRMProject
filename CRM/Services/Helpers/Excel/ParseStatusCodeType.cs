using System.Data;
using System.Reflection;

namespace CRM.Services.Helpers.Excel
{
    /// <summary>
    /// Представляет перечисление кодов статуса (результата) импорта файлов Excel
    /// </summary>
    public enum ParseStatusCodeType
    {
        Fail,
        Success,
        Unknown
    }
}
