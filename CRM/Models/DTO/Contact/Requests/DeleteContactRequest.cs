using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.DTO.Contact.Requests;

public class DeleteContactRequest
{
    [Required]
    public int ContactId { get; set; }

    [Required]
    public string? FullName { get; set; }
}
