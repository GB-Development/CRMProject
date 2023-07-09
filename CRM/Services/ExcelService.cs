using CRM.Model.DTO;
using CRM.Model.Entities;
using CRM.Services.Helpers.Excel;
using CRM.Services.Interfaces;
using CRM.Services.Repositories;
using ExcelDataReader;
using static CRM.Services.Helpers.Excel.ExcelResult;

namespace CRM.Services
{
    /// <summary>
    /// Представляет сервис для работы с импортом файлов Excel
    /// </summary>
    public class ExcelService : IExcelService
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IContactRepository _contactRepo;
        private readonly ICompanyService _companyService;

        /// <summary>
        /// Инцииализирует новый экземпляр класса <see cref="ExcelService"/>
        /// </summary>
        /// <param name="companyRepo"></param>
        public ExcelService(ICompanyRepository companyRepo, IContactRepository contactRepo, ICompanyService companyService)
        {
            _companyRepo = companyRepo;
            _contactRepo = contactRepo;
            _companyService = companyService;
        }

        /// <summary>
        /// Представляет реализацию метода импорта (парсинга) файла Excel
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Возвращает в контроллер результат типа <see cref="ExcelParseResponse"/></returns>
        public async Task<ExcelParseResponse> ExcelParse(IFormFile file)
        {
            try
            {
                if (file == null)
                    return new ExcelParseResponse
                    {
                        Result = false,
                        StatusCode = ParseStatusCodeType.Fail,
                        ParseResultMessage = ExcelParseMessage.FileEmpty
                    };

                List<CompanyExcelDTO>? companiesExcelDTO = new List<CompanyExcelDTO>();
                var fileName = file.FileName;

                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            if (reader.Depth == 0)
                                continue;

                            companiesExcelDTO.Add(new CompanyExcelDTO
                            {
                                CompanyName = (string)reader.GetValue(0),
                                INN = (string)reader.GetValue(1),
                                KPP = (string)reader.GetValue(2),
                                OGRN = (string)reader.GetValue(3),
                                DirectorName = (string)reader.GetValue(4),
                                SupervisorINNFL = (string)reader.GetValue(5),
                                DirectorPost = (string)reader.GetValue(6),
                                PhoneNumber = (string)reader.GetValue(7),
                                ExtraPhoneNumber01 = (string)reader.GetValue(8),
                                ExtraPhoneNumber02 = (string)reader.GetValue(9),
                                ExtraPhoneNumber03 = (string)reader.GetValue(10),
                                ExtraPhoneNumber04 = (string)reader.GetValue(11),
                                ExtraPhoneNumber05 = (string)reader.GetValue(12),
                                ExtraPhoneNumber06 = (string)reader.GetValue(13),
                                ExtraPhoneNumber07 = (string)reader.GetValue(14),
                                ExtraPhoneNumber08 = (string)reader.GetValue(15),
                                ExtraPhoneNumber09 = (string)reader.GetValue(16),
                                Email = (string)reader.GetValue(17),
                                EmailAddress01 = (string)reader.GetValue(18),
                                EmailAddress02 = (string)reader.GetValue(19),
                                EmailAddress03 = (string)reader.GetValue(20),
                                EmailAddress04 = (string)reader.GetValue(21),
                                EmailAddress05 = (string)reader.GetValue(22),
                                EmailAddress06 = (string)reader.GetValue(23),
                                EmailAddress07 = (string)reader.GetValue(24),
                                EmailAddress08 = (string)reader.GetValue(25),
                                EmailAddress09 = (string)reader.GetValue(26),
                                Address = (string)reader.GetValue(27),
                                WebSite = (string)reader.GetValue(28),
                                FocusLink = (string)reader.GetValue(29),
                                CompanyStatus = (string)reader.GetValue(30),
                                DateRegister = (DateTime?)reader.GetValue(31),
                                MSPList = (string)reader.GetValue(32),
                                Revenue = reader.GetValue(33) != null ? (double)reader.GetValue(33) : 0,
                                Balance = reader.GetValue(34) != null ? (double)reader.GetValue(34) : 0,
                                Arbitration = reader.GetValue(35) != null ? (double)reader.GetValue(35) : 0,
                                IncomeLoss = reader.GetValue(36) != null ? (double)reader.GetValue(36) : 0,
                                SpecialTaxRegime = (string)reader.GetValue(37),
                                ValueAddedTax = (string)reader.GetValue(38),
                                MainActivity = (string)reader.GetValue(39),
                                ExtraActivity = (string)reader.GetValue(40),
                                OKPD2 = (string)reader.GetValue(41),
                                RegionRegister = (string)reader.GetValue(42),
                                ObtainedLicenses = (string)reader.GetValue(43),
                                Jobs = (string)reader.GetValue(44),
                                LeasingSubject = (string)reader.GetValue(45),
                                LeasingSubjectCategory = (string)reader.GetValue(46),
                                PropertyPledge = (string)reader.GetValue(47),
                                EmploeeCount = reader.GetValue(48) != null ? (double)reader.GetValue(48) : 0,
                                CompanyBranches = (string)reader.GetValue(49),
                                CompanyBranchesCount = reader.GetValue(50) != null ? (double)reader.GetValue(50) : 0,
                                CompanySource = (string)reader.GetValue(51),
                                CompanySegmentName = (string)reader.GetValue(52)
                            });
                        }
                    }
                }

                if (companiesExcelDTO == null || companiesExcelDTO?.Count == 0)
                {
                    return new ExcelParseResponse
                    {
                        Result = false,
                        StatusCode = ParseStatusCodeType.Unknown
                    };
                }

                List<Company>? companies = _companyService.CreateEntities(companiesExcelDTO);
                
                await _companyRepo.CreateCollectionAsync(companies);
                
                return new ExcelParseResponse
                {
                    Result = true,
                    StatusCode = ParseStatusCodeType.Success,
                    ParseResultMessage = ExcelParseMessage.ImportSuccess
                };
            }

            catch (Exception e)
            {
                return new ExcelParseResponse
                {
                    Result = false,
                    StatusCode = ParseStatusCodeType.Fail,
                    ParseResultMessage = ExcelParseMessage.ImportFail + Environment.NewLine + e.InnerException?.Message.ToString()
                };
            }
        }
    }
}
