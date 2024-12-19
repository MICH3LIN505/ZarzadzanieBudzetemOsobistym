
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

        //    Console.Beep(frequency, 250);
        //}

        fileManagement.CreateUsersFile();

        int loginOption;

        while (true)
        {
            while (userManagement.IsUserLoggedIn == false)
            {
                Console.Clear();
                Display.LoginPanel();
                loginOption = int.Parse(Console.ReadLine());

                switch (loginOption)
                {
                    case 1:
                        userManagement.RegisterUser();
                        break;
                    case 2:
                        var user = userManagement.LoginUser();
                        break;
                    case 3:
                        userManagement.ChangePassword();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Message.Error(ErrorMessage.InvalidChoice());
                        break;
                }
            }

            Display.Logo();
            Sound.WelcomeSound();

            while (userManagement.IsUserLoggedIn == true)
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
                
                if (choice == 6)
                {
                    Sound.LogoutSound();
                    userManagement.LogoutUser();
                }
            }
        }
    }
}