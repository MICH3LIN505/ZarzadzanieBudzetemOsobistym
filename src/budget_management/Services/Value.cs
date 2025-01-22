using budget_management.Messages;
namespace budget_management.Services
{
    internal class Value
    {
        public static int ReadInt(int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value > maxValue || value < minValue)
            {
                Message.Error(ErrorMessage.InvalidValue());
            }
            return value;
        }

        public static decimal ReadDecimal()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Message.Error(ErrorMessage.InvalidValue());
            }
            return value;
        }

        public static string ReadString()
        {
            return Console.ReadLine();
        }

        public static DateTime ReadDateTime()
        {
            DateTime value;
            while (!DateTime.TryParse(Console.ReadLine(), out value))
            {
                Message.Error(ErrorMessage.InvalidValue());
            }
            return value;
        }
    }
}
