namespace CRMIdentity.Data.Models.Dto.Register
{
    public class AccountRegisterResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ErrorMessage { get; set; }

        public AccountRegisterResponseDto(CRMUser user)
        {
            Id = user.Id ?? "";
            Name = user.Name ?? "";
            Email = user.Email ?? "";
            ErrorMessage = "";
        }

        public AccountRegisterResponseDto(string message)
        {
            Id = "";
            Name = "";
            Email = "";
            ErrorMessage = message;
        }

    }
}
