using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Company.Requests;

public class CreateComponyRequest
{
    /// <summary>
    /// Получает или задает наименование компании
    /// </summary>
    [Required]
    public string CompanyName { get; set; }

    /// <summary>
    /// Получает или задает ИНН компании
    /// </summary>
    [Required]
    public string INN { get; set; }

    /// <summary>
    /// Получает или задает КПП компании
    /// </summary>
    public string? KPP { get; set; }

    /// <summary>
    /// Получает или задает ОГРН компании
    /// </summary>
    public string? OGRN { get; set; }

    /// <summary>
    /// Получает или задает ФИО руководителя
    /// </summary>
    public string? DirectorName { get; set; }

    /// <summary>
    /// Получает или задает должность руководителя
    /// </summary>
    public string? DirectorPost { get; set; }

    /// <summary>
    /// Получает или задает адрес компании
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Получает или задает сайт компании
    /// </summary>
    public string? WebSite { get; set; }

    /// <summary>
    /// Получает или задает дату регистрации компании
    /// </summary>
    public DateTime? DateRegister { get; set; }

    /// <summary>
    /// Получает или задает регион регистрации компании
    /// </summary>
    public string? RegionRegister { get; set; }

    /// <summary>
    /// Получает или задает основной вид деятельности компании
    /// </summary>
    public string? MainActivity { get; set; }
}
