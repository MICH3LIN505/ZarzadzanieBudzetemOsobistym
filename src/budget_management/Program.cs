
using budget_management.Services;
using budget_management.Messages;
using budget_management.Sounds;

internal class Program
{
    private static void Main(string[] args)
    {
        FileManagement fileManagement = new();
        TransactionManagement transactionManagement = new();
        UserManagement userManagement = new();

        SettingsMenuFactory settingsMenuFactory = new(transactionManagement, userManagement);
        MenuActionFactory menuActionFactory = new(transactionManagement, settingsMenuFactory);

        //zajefajny tester do dźwięków
        //while (true)
        //{
        //    int frequency;
        //    while (!int.TryParse(Console.ReadLine(), out frequency)) { }

        //        Console.Beep(frequency, 250);
        //}

        fileManagement.CreateFile();

        Display.Logo();
        Sound.WelcomeSound();

        while (true)
        {
            Display.Logo();
            Display.MainMenu();

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Message.Error(ErrorMessage.InvalidChoice());
            }

            var action = menuActionFactory.GetAction(choice);
            action?.Execute();
        }
    }
}