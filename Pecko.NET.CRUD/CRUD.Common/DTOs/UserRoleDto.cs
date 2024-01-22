namespace CRUD.Common.DTOs
{
    public record UserRoleDto
    {
        public string UserName { get; set; } = null!;
        public string? RoleDefinition { get; set; } = null!;
    }
}
