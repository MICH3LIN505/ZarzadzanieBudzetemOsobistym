using budget_management.Services;
namespace budget_management.Factories;

public sealed class SetSoundsAction : IMenuAction
{
    private readonly UserManagement _userManagement;

    public SetSoundsAction(UserManagement userManagement)
    {
        _userManagement = userManagement;
    }

    public void Execute()
    {
        _userManagement.SetSounds();
    }
}
