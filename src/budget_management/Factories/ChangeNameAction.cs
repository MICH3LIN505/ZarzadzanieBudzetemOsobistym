using budget_management.Services;
namespace budget_management.Factories;

public class ChangeNameAction : IMenuAction
{
    private readonly UserManagement _userManagement;

    public ChangeNameAction(UserManagement userManagement)
    {
        _userManagement = userManagement;
    }

    public void Execute()
    {
        _userManagement.ChangeName();
    }
}
