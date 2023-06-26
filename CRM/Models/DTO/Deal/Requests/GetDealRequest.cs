using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Deal.Requests;

public class GetDealRequest
{
    [Required]
    public int DealId { get; set; }
}
