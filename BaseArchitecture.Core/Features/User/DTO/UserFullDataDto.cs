namespace BaseArchitecture.Core.Features.ApplicationUser.DTO
{
    public class UserFullDataDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? NationalNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
