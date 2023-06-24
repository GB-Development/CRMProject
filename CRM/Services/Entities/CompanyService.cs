using CRM.Model.DTO;
using CRM.Data.Entities;
using CRM.Services.Interfaces;

namespace CRM.Services.Entities
{
    /// <summary>
    /// Представляет сервис для работы с объектами типа <see cref="Company"/>
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyExcelDTOService _companyExcelDTOService;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CompanyService"/>
        /// </summary>
        public CompanyService(ICompanyExcelDTOService companyExcelDTOService)
        {
            _companyExcelDTOService = companyExcelDTOService;
        }

        /// <summary>
        /// Представляет реализацию метода создания сущностей (компаний и контактов) при импорте (парсинге) файла Excel
        /// </summary>
        /// <param name="dtos">Список ДТО объектов, полученных при импорте (парсинге)</param>
        /// <returns></returns>
        public List<Company>? CreateEntities(List<CompanyExcelDTO>? dtos)
        {
            if (dtos == null || dtos.Count == 0)
                return new List<Company>();

            List<Company> companies = new List<Company>();

            foreach (var dto in dtos)
            {
                List<Contact> contacts = new List<Contact>();

                var phoneContactProps = _companyExcelDTOService.GetContactProps(1, dto);
                var emailContactProps = _companyExcelDTOService.GetContactProps(2, dto);

                foreach (var phone in phoneContactProps)
                {
                    contacts.Add(new Contact
                    {
                        PhoneNumber = phone
                    });
                }

                foreach (var email in emailContactProps)
                {
                    contacts.Add(new Contact
                    {
                        Email = email
                    });
                }

                companies.Add(new Company
                {
                    CompanyName = dto.CompanyName,
                    INN = dto.INN,
                    KPP = dto.KPP,
                    OGRN = dto.OGRN,
                    DirectorName = dto.DirectorName,
                    DirectorPost = dto.DirectorPost,
                    Address = dto.Address,
                    WebSite = dto.WebSite,
                    DateRegister = dto.DateRegister,
                    RegionRegister = dto.RegionRegister,
                    MainActivity = dto.MainActivity,
                    Contacts = contacts
                });
            }

            return companies;
        }
    }
}
