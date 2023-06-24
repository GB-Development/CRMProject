using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Company.Requests;

public class GetComponyRequest
{
    [Required]
    public int CompanyId { get; set; }
}
