using System.Globalization;

namespace budget_management.Messages
{
    public static class TransactionMessage
    {
        public static string Currency() => "PLN";
        public static string AddTransactionHeader() => "=== Dodawanie transakcji ===";
        public static string CalculateAverageExpensesHeader() => "=== Obliczanie średniej ===";
        public static string DisplayExpensesHeader() => "=== Wyświetlanie transakcji ===";
        public static string SetMonthBudgetHeader() => "=== Ustalanie budżetu ===";
        public static string AddAmount() => "Podaj kwotę transakcji: ";
        public static string AddNote() => "Opcjonalna notatka (wciśnij Enter, aby pominąć): ";
        public static string AddDate() => "Podaj datę (RRRR-MM-DD): ";
        public static string TransactionAdded() => "Transakcja została dodana";
        public static string AddYear() => "Podaj rok: ";
        public static string AddMonth() => "Podaj miesiąc: ";
        public static string NoTransactions() => "Brak transakcji w wybranym miesiącu.";
        public static string AverageExpenses(string month, int year) => $"Średnie wydatki za {month} {year}: ";
        public static string AverageIncomes(string month, int year) => $"Średnie przychody za {month} {year}: ";
        public static string MonthBalance(string month, int year) => $"Bilans za {month} {year} wynosi ";
        public static string CurrentMonthBudget(decimal CurrentMonthBudget) => $"Twój aktualny budżet miesięczny wynosi: {CurrentMonthBudget} {Currency()}";
        public static string WannaSetNewBudget() => "Czy chcesz ustalić nowy budżet miesięczny?";
        public static string SetNewBudget() => "Podaj nowy budżet miesięczny: ";
        public static string BudgetSet(decimal NewBudget) => $"Twój nowy budżet miesięczny wynosi {NewBudget} {Currency()}";
    }
}