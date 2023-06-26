using CRM.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Deal.Requests;

public class UpdateDealRequest
{
    public CRM.Data.Entities.Deal Deal { get; set; }
}
