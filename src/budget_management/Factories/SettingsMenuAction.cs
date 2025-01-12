using budget_management.Messages;
namespace budget_management.Factories;

//MENU USTAWIEŃ
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

        int settingsChoice;
        while (!int.TryParse(Console.ReadLine(), out settingsChoice))
        {
            Message.Error(ErrorMessage.InvalidChoice());
        }

        if (settingsChoice == 6) return;

        var action = _settingsMenuFactory.GetAction(settingsChoice);
        action?.Execute();
    }
}
