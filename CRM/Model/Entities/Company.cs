using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Model.Entities
{
    [Table("Company")]
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public string? INN { get; set; }

        public string? KPP { get; set; }

        public string? OGRN { get; set; }

        public string? SupervisorFullName { get; set; }

        public string? SupervisorINNFL { get; set; }

        public string? SupervisorJobTitle { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ExtraPhoneNumber01 { get; set; }

        public string? ExtraPhoneNumber02 { get; set; }

        public string? ExtraPhoneNumber03 { get; set; }

        public string? ExtraPhoneNumber04 { get; set; }

        public string? ExtraPhoneNumber05 { get; set; }

        public string? ExtraPhoneNumber06 { get; set; }

        public string? ExtraPhoneNumber07 { get; set; }

        public string? ExtraPhoneNumber08 { get; set; }

        public string? ExtraPhoneNumber09 { get; set; }

        public string? EmailAddress { get; set; }

        public string? EmailAddress01 { get; set; }

        public string? EmailAddress02 { get; set; }

        public string? EmailAddress03 { get; set; }

        public string? EmailAddress04 { get; set; }

        public string? EmailAddress05 { get; set; }

        public string? EmailAddress06 { get; set; }

        public string? EmailAddress07 { get; set; }

        public string? EmailAddress08 { get; set; }

        public string? EmailAddress09 { get; set; }

        public string? FullAddress { get; set; }

        public string? SiteLink { get; set; }

        public string? FocusLink { get; set; }

        public string? CompanyStatus { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string? MSPList { get; set; }

        public double? Revenue { get; set; }

        public double? Balance { get; set; }

        public double? Arbitration { get; set; }

        public double? IncomeLoss { get; set; }

        public string? SpecialTaxRegime { get; set; }

        public string? ValueAddedTax { get; set; }

        public string? MainActivity { get; set; }

        public string? ExtraActivity { get; set; }

        public string? OKPD2 { get; set; }

        public string? RegistrationRegion { get; set; }

        public string? ObtainedLicenses { get; set; }

        public string? Jobs { get; set; }

        public string? LeasingSubject { get; set; }

        public string? LeasingSubjectCategory { get; set; }

        public string? PropertyPledge { get; set; }

        public double? EmploeeCount { get; set; }

        public string? CompanyBranches { get; set; }

        public double? CompanyBranchesCount { get; set; }

        public string? CompanySource { get; set; }

        public string? CompanySegmentName { get; set; }


    }
}
