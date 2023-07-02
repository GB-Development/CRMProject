namespace CRM.WebClient.Models;

public class CrmDeal
{
    public string ManagerId { get; set; }
    public CrmCompany? Company { get; set; }
    public DateTime? DateContact { get; set; }
}
