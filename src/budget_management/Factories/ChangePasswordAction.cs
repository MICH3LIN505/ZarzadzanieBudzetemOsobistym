using budget_management.Services;
namespace budget_management.Factories;

public sealed class ChangePasswordAction : IMenuAction
{
    private readonly UserManagement _userManagement;

    public ChangePasswordAction(UserManagement userManagement)
    {
        _userManagement = userManagement;
    }

    public void Execute()
    {
        _userManagement.ChangePassword();
    }
}
