using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Deal.Requests;

public class DeleteDealRequest
{
    [Required]
    public int DealId { get; set; }
}
