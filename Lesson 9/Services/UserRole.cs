public class UserRole : IUserRole
{
    public string RoleName { get; private set; }

    public UserRole(string roleName)
    {
        RoleName = roleName;
    }

    public bool CanEditData() => RoleName.ToLower() == "admin";
    public bool CanViewStatistics() => RoleName.ToLower() == "admin" || RoleName.ToLower() == "student";
}
