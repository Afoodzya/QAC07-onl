public interface IUserRole
{
    string RoleName { get; }
    bool CanEditData();
    bool CanViewStatistics();
}
