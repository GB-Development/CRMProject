using CRM.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.Model.DTO
{
    public class CompanyCreateDto
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string INN { get; set; }
    }
}
