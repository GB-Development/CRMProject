using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class Contact
    {
		public int ContactId { get; set; }
		public int CompanyId { get; set; }
		public string ContactName { get; set; }
		public string ContactPost { get; set; }
		public string ContactPhone { get; set; }
		public string ContactMail { get; set; }
		public string ContactAdress { get; set; }
	}
}
