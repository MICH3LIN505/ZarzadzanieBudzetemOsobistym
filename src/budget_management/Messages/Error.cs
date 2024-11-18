// to jest plik odpowiadający za treść wyświetlanych błędów

namespace budget_management.Messages
{
    public class Error
    {
        public void InvalidChoice() { Console.Beep(); Console.WriteLine("Nieprawidłowy wybór"); }
        public void FileExists() => Console.WriteLine("Plik już istnieje");
    }
}