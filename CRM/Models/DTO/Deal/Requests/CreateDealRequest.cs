using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Deal.Requests;

public class CreateDealRequest
{
    /// <summary>
    /// Получает или задает ИД компании
    /// </summary>
    [Required]
    public int? CompanyId { get; set; }

    /// <summary>
    /// Получает или задает дату создания сделки
    /// </summary>
    public DateTime? DateCreate { get; set; }

    /// <summary>
    /// Получает или задает дату контакта
    /// </summary>
    public DateTime? DateContact { get; set; }
}
