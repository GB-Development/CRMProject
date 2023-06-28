using CRM.Model.Entities;

namespace CRM.Model.DTO
{
    public class DealUpdateDto
    {
        public int DealId { get; set; }
        public string ManagerId { get; set; }
        public Company? Company { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateContact { get; set; }

    }
}
