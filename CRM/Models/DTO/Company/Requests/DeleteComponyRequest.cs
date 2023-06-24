using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.DTO.Company.Requests;

public class DeleteComponyRequest
{
    [Required]
    public int CompanyId { get; set; }
    [Required]
    public string CompanyName { get; set; }
}
