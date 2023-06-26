using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Contact.Requests;

public class GetContactRequest
{
    [Required]
    public int ContactId { get; set; }
}
