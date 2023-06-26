using System.ComponentModel.DataAnnotations;

namespace CRM.Models.DTO.Contact.Requests;

public class CreateContactRequest
{
    /// <summary>
    /// Получает или задает ФИО контакта
    /// </summary>
    [Required]
    public string? FullName { get; set; }

    /// <summary>
    /// Получает или задает телефонный номер контакта
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Получает или задает адрес электронной почты контакта
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Получает или задает адрес контакта
    /// </summary>
    public string? Address { get; set; }
}
