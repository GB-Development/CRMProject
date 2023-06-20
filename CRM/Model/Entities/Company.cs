using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Model.Entities
{
    /// <summary>
    /// Представляет класс, описывающий сущность "Компания"
    /// </summary>
    [Table("Company")]
    public class Company
    {
        /// <summary>
        /// Получает или задает ИД компании
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        /// <summary>
        /// Получает или задает наименование компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Получает или задает ИНН компании
        /// </summary>
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

        /// <summary>
        /// Получает или задает коллекцию контактов компании
        /// </summary>
        public List<Contact>? Contacts { get; set; }

    }
}
