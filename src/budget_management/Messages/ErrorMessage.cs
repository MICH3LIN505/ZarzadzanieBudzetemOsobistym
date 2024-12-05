
namespace budget_management.Messages
{
    public static class ErrorMessage
    {
        public static void InvalidChoice()
        {
            string message = "Nieprawidłowy wybór";
            Sound.ErrorSound();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("/!\\ ");
            Console.WriteLine(message);
            //poczekaj 2 sekundy i skasuj ostatnią linię
            System.Threading.Thread.Sleep(2000);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(16, Console.CursorTop - 1);
            //usuń jeden znak
            Console.Write("\b");
            Console.Write(" ");
            Console.Write("\b");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void FileExists() => Console.WriteLine("Plik już istnieje");
    }
}