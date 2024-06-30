namespace Account.Domain.User.Roles;

public sealed record UserRoles
{
    public const string IdleUser = "None";
    public const string Nurse = "Nurse";
    public const string CEO = "CEO";
}
