namespace CRM.Model.DTO
{
    public class ContactUpdateDto
    {
        public int ContactId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int CompanyId { get; set; }

    }
}
