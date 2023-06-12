using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class Company
    {
		public int CompanyId { get; set; }
		public string CompanyName { get; set; }
		public string CompanyINN { get; set; }
		public string CompanyKPP { get; set; }
		public string CompanyOGRN { get; set; }
		public string CompanyDirectorName { get; set; }
		public string CompanyDirectorINN { get; set; }
		public string CompanyDirectorPost { get; set; }
		public string CompanyAdress { get; set; }
		public string CompanyWeb { get; set; }
		public string CompanyFocus { get; set; }
		public string CompanyStatus { get; set; }
		public string CompanyDateReg { get; set; }
		public string CompanyMSP { get; set; }
		public int CompanyRevenue { get; set; }
		public int CompanyBalance { get; set; }
		public int CompanyArbitrage { get; set; }
		public int CompanyProfit { get; set; }
		public string CompanyTaxMode { get; set; }
		public int CompanyTax { get; set; }
		public string CompanyMainActivity { get; set; }
		public string CompanyOtherActivity { get; set; }
		public string CompanyOKPD2 { get; set; }
		public string CompanyRegionReg { get; set; }
		public string CompanyLicenses { get; set; }
		public string CompanyVacancies { get; set; }
		public string CompanyLeasing { get; set; }
		public string CompanyLeasingCategory { get; set; }
		public string CompanyCollateral { get; set; }
		public int CompanyEmployeesNum { get; set; }
		public string CompanyBranches { get; set; }
		public int CompanyBranchesNum { get; set; }
		public string CompanySource { get; set; }
		public string CompanySegmentName { get; set; }
	}
}
