using System.ComponentModel.DataAnnotations;

namespace CRM.Model.DTO
{
    public class CompanyUpdateDto
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string INN { get; set; }
        public string? KPP { get; set; }
        public string? OGRN { get; set; }
        public string? DirectorName { get; set; }
        public string? DirectorPost { get; set; }
        public string? Address { get; set; }
        public string? WebSite { get; set; }
        public DateTime? DateRegister { get; set; }
        public string? RegionRegister { get; set; }
        public string? MainActivity { get; set; }
    }
}
