using CRM.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM.Model.DTO
{
    public class CompanyDeleteDto
    {
        [Required]
        public int CompanyId { get; set; }
    }
}
