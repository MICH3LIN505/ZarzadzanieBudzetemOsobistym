using budget_management.Messages;
using budget_management.Services;
namespace budget_management.Factories;

public class SettingsMenuAction : IMenuAction
{
    private readonly SettingsMenuFactory _settingsMenuFactory;

    public SettingsMenuAction(SettingsMenuFactory settingsMenuFactory)
    {
        _settingsMenuFactory = settingsMenuFactory;
    }

    public void Execute()
    {
        Display.Logo();
        Display.Settings();

        int settingsChoice = Value.ReadInt();

        if (settingsChoice == 6) return;

        var action = _settingsMenuFactory.GetAction(settingsChoice);
        action?.Execute();
    }
}
