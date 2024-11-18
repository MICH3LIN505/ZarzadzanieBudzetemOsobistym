
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

        FileManagement.CreateFile();

        Display.MainMenu();

        while (true)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TransactionManagement.AddTransaction();
                    //dodaje nową transakcję i zapisuje ją do pliku
                    //pyta użytkownika o kwotę, opcjonalną notatkę oraz datę
                    //wszystko zapisuje do pliku transactions.json
                    break;
                case "2":
                    TransactionManagement.DisplayTotalExpenses();
                    //sumuje i wyświetla wszystkie wydatki zapisane w pliku transactions.json
                    break;
                case "3":
                    TransactionManagement.CalculateAverageExpenses();
                    //wylicza średnią wydatków zapisanych w pliku transactions.json
                    break;
                case "4":
                    TransactionManagement.DisplayExpensesSpecificMonthAndYear();
                    //wylicza średnią wydatków z wybranego roku i miesiąca zapisanych w pliku transactions.json
                    break;
                case "5":
                    Display.Settings();
                    string settingsChoice = Console.ReadLine();

                    while (settingsChoice!="6")
                    {
                        switch (settingsChoice)
                        {
                            case "1":
                                TransactionManagement.SetMonthBudget();
                                //ustala budżet miesięczny i zapisuje go do pliku config.json
                                break;
                            case "2":
                                UserManagement.SetPayday();
                                //ustala dzień wypłaty i zapisuje go do pliku config.json
                                break;
                            case "3":
                                //FileManagement.SaveToFile();
                                //zapisuje wszystkie zmienne do pliku config.json
                                break;
                            case "4":
                                //FileManagement.ReadFromFile();
                                //odczytuje wszystkie zmienne z pliku config.json i aktualizuje zmienne globalne
                                break;
                            case "5":
                                FileManagement.DeleteFile();
                                //usuwa plik config.json i transaction.json, pyta użytkownika o potwierdzenie
                                break;
                            default:
                                Error.InvalidChoice();
                                break;
                        }
                    }
                    break;
                case "6":
                    Info.Goodbye();
                    Environment.Exit(0);
                    break;
                default:
                    Error.InvalidChoice();
                    break;
            }
        }
    }
}
