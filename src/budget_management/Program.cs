
using budget_management.Services;
using budget_management.Messages;

internal class Program
{
    private static void Main(string[] args)
    {
        // Inicjalizacja menedżerów
        FileManagement fileManagement = new();
        TransactionManagement transactionManagement = new();
        UserManagement userManagement = new();

        // Fabryki
        SettingsMenuFactory settingsMenuFactory = new(transactionManagement, userManagement);
        MenuActionFactory menuActionFactory = new(transactionManagement, settingsMenuFactory);

        fileManagement.CreateFile();

        while (true)
        {
            Display.MainMenu();

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                ErrorMessage.InvalidChoice();
            }

            var action = menuActionFactory.GetAction(choice);
            action?.Execute();
            //ErrorMessage.InvalidChoice();
        }
    }
}



    //while (true)
    //{
    //    int choice;

    //    while (!int.TryParse(Console.ReadLine(), out choice))
    //    {
    //        ErrorMessage.InvalidChoice();
    //    };

    //    switch (choice)
    //    {
    //        case 1:
    //            TransactionManagement.AddTransaction();
    //            break;
    //        case 2:
    //            TransactionManagement.DisplayTotalExpenses();
    //            break;
    //        case 3:
    //            TransactionManagement.CalculateAverageExpenses();
    //            break;
    //        case 4:
    //            TransactionManagement.DisplayExpensesSpecificMonthAndYear();
    //            break;
    //        case 5:
    //            Display.Settings();

    //            int settingsChoice;
    //            while (!int.TryParse(Console.ReadLine(), out settingsChoice))
    //            {
    //                ErrorMessage.InvalidChoice();
    //            };

    //            while (settingsChoice != 3)
    //            {
    //                switch (settingsChoice)
    //                {
    //                    case 1:
    //                        TransactionManagement.SetMonthBudget();
    //                        break;
    //                    case 2:
    //                        UserManagement.SetPayday();
    //                        break;
    //                    default:
    //                        Sound.Error();
    //                        ErrorMessage.InvalidChoice();
    //                        break;
    //                }
    //            }
    //            break;
    //        case 6:
    //            InfoMessage.Goodbye();
    //            Environment.Exit(0);
    //            break;
    //        default:
    //            ErrorMessage.InvalidChoice();
    //            break;
    //    }
    //}
//}
//}
