// to jest plik odpowiadający za treść wyświetlanych komunikatów informacyjnych

namespace budget_management.Messages
{
    public class Info
    {
        public void SetMonthBudget() => Console.WriteLine("Podaj nowy budżet miesięczny: ");
        public void AddExpense() => Console.WriteLine("Podaj kwotę wydatku:");
        public void DisplayTotalExpenses() => Console.WriteLine("Suma wydatków wynosi: ");
        public void DisplayAllExpenses() => Console.WriteLine("Wszystkie wydatki z ostatnich 24 miesięcy:");
        public void CalculateAverageExpenses() => Console.WriteLine("Średnia wydatków w ciągu miesiąca wynosi: ");
        public void DisplayExpensesSpecificYear() => Console.WriteLine("Podaj rok: ");
        public void DisplayExpensesSpecificMonth() => Console.WriteLine("Podaj miesiąc: ");
        public void FileCreated() => Console.WriteLine("Plik 'budget.txt' utworzony pomyślnie.");
        public void FileSaved() => Console.WriteLine("Zapisano do pliku");
        public void ReadFromFile() => Console.WriteLine("Wczytano z pliku");
        public void Goodbye() => Console.WriteLine("Do widzenia!");
    }
}