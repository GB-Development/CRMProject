namespace CRM.Model.DTO
{
    /// <summary>
    /// Представляет класс, описывающий сущность DTO, формируемую при импорте файла Excel
    /// </summary>
    public class CompanyExcelDTO
    {
        /// <summary>
        /// Получает или задает ИД компании
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Получает или задает Наименование
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Получает или задает ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// Получает или задает КПП
        /// </summary>
        public string? KPP { get; set; }

        /// <summary>
        /// Получает или задает ОГРН
        /// </summary>
        public string? OGRN { get; set; }

        /// <summary>
        /// Получает или задает ФИО руководителя
        /// </summary>
        public string? DirectorName { get; set; }

        /// <summary>
        /// Получает или задает Должность руководителя
        /// </summary>
        public string? DirectorPost { get; set; }

        /// <summary>
        /// Получает или задает Адрес
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Получает или задает Ссылка на сайт
        /// </summary>
        public string? WebSite { get; set; }

        /// <summary>
        /// Получает или задает Дата регистрации
        /// </summary>
        public DateTime? DateRegister { get; set; }

        /// <summary>
        /// Получает или задает Регион регистрации
        /// </summary>
        public string? RegionRegister { get; set; }

        /// <summary>
        /// Получает или задает Основной вид деятельности
        /// </summary>
        public string? MainActivity { get; set; }

        /// <summary>
        /// Получает или задает ИННФЛ руководителя
        /// </summary>
        public string? SupervisorINNFL { get; set; }

        /// <summary>
        /// Получает или задает Номер телефона
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 1
        /// </summary>
        public string? ExtraPhoneNumber01 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 2
        /// </summary>
        public string? ExtraPhoneNumber02 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 3
        /// </summary>
        public string? ExtraPhoneNumber03 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 4
        /// </summary>
        public string? ExtraPhoneNumber04 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 5
        /// </summary>
        public string? ExtraPhoneNumber05 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 6
        /// </summary>
        public string? ExtraPhoneNumber06 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 7
        /// </summary>
        public string? ExtraPhoneNumber07 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 8
        /// </summary>
        public string? ExtraPhoneNumber08 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительный телефон 9
        /// </summary>
        public string? ExtraPhoneNumber09 { get; set; }

        /// <summary>
        /// Получает или задает Электронная почта
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 1
        /// </summary>
        public string? EmailAddress01 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 2
        /// </summary>
        public string? EmailAddress02 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 3
        /// </summary>
        public string? EmailAddress03 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 4
        /// </summary>
        public string? EmailAddress04 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 5
        /// </summary>
        public string? EmailAddress05 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 6
        /// </summary>
        public string? EmailAddress06 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 7
        /// </summary>
        public string? EmailAddress07 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 8
        /// </summary>
        public string? EmailAddress08 { get; set; }

        /// <summary>
        /// Получает или задает Дополнительная электронная почта 9
        /// </summary>
        public string? EmailAddress09 { get; set; }

        /// <summary>
        /// Получает или задает Карточка в Фокусе
        /// </summary>
        public string? FocusLink { get; set; }

        /// <summary>
        /// Получает или задает Статус
        /// </summary>
        public string? CompanyStatus { get; set; }

        /// <summary>
        /// Получает или задает Реестр МСП
        /// </summary>
        public string? MSPList { get; set; }

        /// <summary>
        /// Получает или задает Выручка, тыс. руб
        /// </summary>
        public double? Revenue { get; set; }

        /// <summary>
        /// Получает или задает Баланс, тыс. руб
        /// </summary>
        public double? Balance { get; set; }

        /// <summary>
        /// Получает или задает Арбитраж (ответчик), тыс. руб
        /// </summary>
        public double? Arbitration { get; set; }

        /// <summary>
        /// Получает или задает Чистая прибыль/ убыток, тыс. руб
        /// </summary>
        public double? IncomeLoss { get; set; }

        /// <summary>
        /// Получает или задает Специальный налоговый режим
        /// </summary>
        public string? SpecialTaxRegime { get; set; }

        /// <summary>
        /// Получает или задает Налог на добавленную стоимость
        /// </summary>
        public string? ValueAddedTax { get; set; }

        /// <summary>
        /// Получает или задает Другие виды деятельности
        /// </summary>
        public string? ExtraActivity { get; set; }

        /// <summary>
        /// Получает или задает Предметы закупок (ОКПД2)
        /// </summary>
        public string? OKPD2 { get; set; }

        /// <summary>
        /// Получает или задает Полученные лицензии
        /// </summary>
        public string? ObtainedLicenses { get; set; }

        /// <summary>
        /// Получает или задает Вакансии
        /// </summary>
        public string? Jobs { get; set; }

        /// <summary>
        /// Получает или задает Предмет лизинга
        /// </summary>
        public string? LeasingSubject { get; set; }

        /// <summary>
        /// Получает или задает Категория предмета лизинга
        /// </summary>
        public string? LeasingSubjectCategory { get; set; }

        /// <summary>
        /// Получает или задает Залог имущества
        /// </summary>
        public string? PropertyPledge { get; set; }

        /// <summary>
        /// Получает или задает Количество сотрудников
        /// </summary>
        public double? EmploeeCount { get; set; }

        /// <summary>
        /// Получает или задает Филиалы
        /// </summary>
        public string? CompanyBranches { get; set; }

        /// <summary>
        /// Получает или задает Количество филиалов
        /// </summary>
        public double? CompanyBranchesCount { get; set; }

        /// <summary>
        /// Получает или задает Источник
        /// </summary>
        public string? CompanySource { get; set; }

        /// <summary>
        /// Получает или задает Название сегмента
        /// </summary>
        public string? CompanySegmentName { get; set; }
    }
}
