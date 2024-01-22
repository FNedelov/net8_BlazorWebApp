namespace CRUD.Common.DTOs
{
    public record AuthenticationResponseDto
    {
        public string? UserName { get; set; }
        public string? JwtToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
