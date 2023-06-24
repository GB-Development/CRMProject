using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Data.Entities
{
    /// <summary>
    /// Представляет класс, описывающий сущность "Сделка"
    /// </summary>
    [Table("Deal")]
    public class Deal
    {
        /// <summary>
        /// Получает или задает ИД сделки
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DealId { get; set; }

        /// <summary>
        /// Получает или задает ИД компании
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Получает или задает компанию
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Получает или задает дату создания сделки
        /// </summary>
        public DateTime? DateCreate { get; set; }

        /// <summary>
        /// Получает или задает дату контакта
        /// </summary>
        public DateTime? DateContact { get; set; }
    }
}
