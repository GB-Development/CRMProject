using CRM.Data.Entities;

namespace CRM.Models.DTO.Contact.Requests;

public class UpdateContactRequest
{
    public CRM.Data.Entities.Contact Contact { get; set; }
}
