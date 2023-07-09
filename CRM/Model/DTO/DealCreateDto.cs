using CRM.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM.Model.DTO
{
    public class DealCreateDto
    {
        [Required]
        public string ManagerId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime? DateContact { get; set; }
    }
}
