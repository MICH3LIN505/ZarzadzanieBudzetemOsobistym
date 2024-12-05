
namespace budget_management.Messages
{
    public static class Sound
    {
        public static void ErrorSound() => Console.Beep();
        public static void SuccessSound() => Console.Beep();
        public static void WarningSound() => Console.Beep();
        public static void InfoSound() => Console.Beep();

    }
}