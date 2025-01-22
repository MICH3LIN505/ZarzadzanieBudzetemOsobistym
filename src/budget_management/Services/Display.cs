
namespace budget_management.Messages;

public static class Display
{
    public static void Logo(bool Color = true)
    {
        Console.Clear();
        if (Color)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.WriteLine("$$$$$$$$\\ $$$$$$$\\   $$$$$$\\  ");
        Console.WriteLine("\\____$$  |$$  __$$\\ $$  __$$\\ ");
        Console.WriteLine("    $$  / $$ |  $$ |$$ /  $$ |");
        Console.WriteLine("   $$  /  $$$$$$$\\ |$$ |  $$ |");
        Console.WriteLine("  $$  /   $$  __$$\\ $$ |  $$ |");
        Console.WriteLine(" $$  /    $$ |  $$ |$$ |  $$ |");
        Console.WriteLine("$$$$$$$$\\ $$$$$$$  | $$$$$$  |");
        Console.WriteLine("\\________|\\_______/  \\______/ - Zarządzanie Budżetem Osobistym");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void LoginPanel()
    {
        Console.WriteLine();
        Console.WriteLine(DisplayMessage.LoginPanelHeader());
        Console.WriteLine();
        Console.WriteLine("1. " + DisplayMessage.Login());
        Console.WriteLine("2. " + DisplayMessage.Register());
        Console.WriteLine("3. " + DisplayMessage.Exit());
        Console.WriteLine();
        Console.Write(DisplayMessage.ChooseOption());
    }
    public static void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine(DisplayMessage.MainMenuHeader());
        Console.WriteLine();
        Console.WriteLine("1. " + DisplayMessage.AddTransaction());
        Console.WriteLine("2. " + DisplayMessage.CalculateAverage());
        Console.WriteLine("3. " + DisplayMessage.ShowTransactions());
        Console.WriteLine("4. " + DisplayMessage.Settings());
        Console.WriteLine("5. " + DisplayMessage.Logout());
        Console.WriteLine("6. " + DisplayMessage.Exit());
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }

    public static void Settings()
    {
        Console.WriteLine();
        Console.WriteLine(DisplayMessage.SettingsHeader());
        Console.WriteLine();
        Console.WriteLine("1. " + DisplayMessage.SetMonthBudget());
        Console.WriteLine("2. " + DisplayMessage.ChangeName());
        Console.WriteLine("3. " + DisplayMessage.SoundsSettings());
        Console.WriteLine("4. " + DisplayMessage.ChangePassword());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5. " + DisplayMessage.DeleteUser());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("6. " + DisplayMessage.BackToMenu());
        Console.WriteLine();
        Console.Write(DisplayMessage.ChooseOption());
    }
}