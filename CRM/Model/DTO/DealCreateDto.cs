using CRM.Model.Entities;

namespace CRM.Model.DTO
{
    public class DealCreateDto
    {
        public string ManagerId { get; set; }
        public CompanyCreateDto? Company { get; set; }
        public DateTime? DateContact { get; set; }
    }
}
