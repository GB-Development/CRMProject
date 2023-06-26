using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Company.Requests;

public class GetCompanyRequest
{
    [Required]
    public int CompanyId { get; set; }
}
