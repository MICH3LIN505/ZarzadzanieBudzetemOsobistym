using budget_management.Messages;

namespace budget_management.Factories
{
    internal class VeryImportantAction : IMenuAction
    {
        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ____  _____  _____   ______  ________ ");
            Console.WriteLine("|_   \\| _ _ ||_   _|.' ___  ||_   __  |");
            Console.WriteLine("  |   \\ | |    | | / .'   \\_|  | |_ \\_|");
            Console.WriteLine("  | |\\ \\| |    | | | |         |  _| _");
            Console.WriteLine(" _| |_\\   |_  _| |_\\ `.___.'\\ _| |__/ | _  _  _");
            Console.WriteLine("|_____|\\____||_____|`.____ .'|________|(_)(_)(_)");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Tak, znalazłeś to czego szukałeś. Gratulacje!");
            Console.WriteLine();
            Console.WriteLine("DO ROBOTY SIĘ ZABIERZ");
            Console.WriteLine();

            Console.Beep(500, 250);
            Console.Beep(500, 250);
            Console.Beep(500, 250);
            Console.Beep(600, 500);

            Console.WriteLine(InfoMessage.PressAnyKey());
            Console.ReadKey();
        }
    }
}
