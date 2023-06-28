using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Model.Entities
{
    /// <summary>
    /// Представляет класс, описывающий сущность "Контакт"
    /// </summary>
    [Table("Contact")]
    public class Contact
    {
        /// <summary>
        /// Получает или задает ИД контакта
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        /// <summary>
        /// Получает или задает ФИО контакта
        /// </summary>
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

        [Required]
        [ForeignKey(nameof(ContactId))]
        public int CompanyId { get; set; }

    }
}
