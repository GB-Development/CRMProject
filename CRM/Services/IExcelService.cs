using CRM.Model.Entities;
using CRM.Services.Helpers;

namespace CRM.Services
{
    public interface IExcelService
    {
        ExcelParseResponse ExcelParse(IFormFile file);
    }
}
