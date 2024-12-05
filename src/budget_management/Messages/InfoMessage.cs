
namespace budget_management.Messages
{
    public static class InfoMessage
    {
        public static void SetMonthBudget() => Console.WriteLine("Podaj nowy budżet miesięczny: ");
        public static void AddExpense() => Console.WriteLine("Podaj kwotę wydatku:");
        public static void DisplayTotalExpenses() => Console.WriteLine("Suma wydatków wynosi: ");
        public static void DisplayAllExpenses() => Console.WriteLine("Wszystkie wydatki z ostatnich 24 miesięcy:");
        public static void CalculateAverageExpenses() => Console.WriteLine("Średnia wydatków w ciągu miesiąca wynosi: ");
        public static void DisplayExpensesSpecificYear() => Console.WriteLine("Podaj rok: ");
        public static void DisplayExpensesSpecificMonth() => Console.WriteLine("Podaj miesiąc: ");
        public static void FileCreated() => Console.WriteLine("Plik 'budget.txt' utworzony pomyślnie.");
        public static void FileSaved() => Console.WriteLine("Zapisano do pliku");
        public static void ReadFromFile() => Console.WriteLine("Wczytano z pliku");
        public static void Goodbye() => Console.WriteLine("Do widzenia!");
    }
}