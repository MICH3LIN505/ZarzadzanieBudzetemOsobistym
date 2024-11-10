
namespace Domain.Entities;
using budget_management.Services;
using budget_management.Messages;
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Display Display = new();
        TransactionManagement TransactionManagement = new();
        UserManagement UserManagement = new();
        FileManagement FileManagement = new();
        Info Info = new();
        Error Error = new();

        int choice;
        do
        {
            Display.MainMenu();

            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    TransactionManagement.AddTransaction();
                    break;
                case 2:
                    TransactionManagement.DisplayTotalExpenses();
                    break;
                case 3:
                    TransactionManagement.CalculateAverageExpenses();
                    break;
                case 4:
                    TransactionManagement.DisplayExpensesSpecificMonthAndYear();
                    break;
                case 5:
                    Display.Settings();
                    int settingsChoice = int.Parse(Console.ReadLine());
                    switch (settingsChoice)
                    {
                        case 1:
                            TransactionManagement.SetMonthBudget();
                            break;
                        case 2:
                            UserManagement.SetPayday();
                            break;
                        case 3:
                            FileManagement.SaveToFile();
                            break;
                        case 4:
                            FileManagement.ReadFromFile();
                            break;
                        case 5:
                            FileManagement.DeleteFile();
                            break;
                        default:
                            Error.InvalidChoice();
                            break;
                    }
                    break;
                case 6:
                    Info.Goodbye();
                    break;
                default:
                    Error.InvalidChoice();
                    break;
            }
        } while (choice != 6);
    }
}
