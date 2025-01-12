
using budget_management.Services;
using budget_management.Messages;
using budget_management.Sounds;
using budget_management.Factories;

internal class Program
{
    private static void Main(string[] args)
    {
        FileManagement fileManagement = new();
        TransactionManagement transactionManagement = new();
        UserManagement userManagement = new();

        SettingsMenuFactory settingsMenuFactory = new(transactionManagement, userManagement);
        MenuActionFactory menuActionFactory = new(transactionManagement, settingsMenuFactory);

        fileManagement.CreateUsersFile();

        int loginOption;

        while (true)
        {
            while (userManagement.IsUserLoggedIn == false)
            {
                Display.Logo(false);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(InfoMessage.Welcome());
                Console.ForegroundColor = ConsoleColor.White;

                Display.LoginPanel();

                loginOption = int.Parse(Console.ReadLine());

                switch (loginOption)
                {
                    case 1:
                        var user = userManagement.LoginUser();
                        break;
                    case 2:
                        userManagement.RegisterUser();
                        break;
                    case 3:
                        fileManagement.ExitProcedure(false);
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

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(InfoMessage.WelcomeUser(transactionManagement.DisplayBalance()));
                Console.ForegroundColor = ConsoleColor.White;

                Display.MainMenu();

                int choice;

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Message.Error(ErrorMessage.InvalidChoice());
                }

                var action = menuActionFactory.GetAction(choice);
                action?.Execute();
                
                if (choice == 5)
                {
                    Sound.LogoutSound();
                    userManagement.LogoutUser();
                }
            }
        }
    }
}