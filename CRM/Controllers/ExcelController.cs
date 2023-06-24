using CRM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService _excelService;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ExcelController"/>
        /// </summary>
        /// <param name="excelService"></param>
        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        /// <summary>
        /// Представляет метод импорта файла Excel
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(IFormFile file)
        {
            var result = await _excelService.ExcelParse(file);

            return Ok(result);
        }
    }
}
