
using budget_management.Services;
namespace budget_management.Sounds
{
    public static class Sound
    {
        public static void ErrorSound()
        {
            UserManagement userManagement = new();
            if(userManagement.GetSoundsSetting())
            {
                Console.Beep(700, 250);
                Console.Beep(1000, 60);
            }
        }
        public static void SuccessSound()
        {
            UserManagement userManagement = new();
            if (userManagement.GetSoundsSetting())
            {
                Console.Beep(1000, 250);
                Console.Beep(2000, 250);
            }
        }
        public static void WarningSound()
        {
            UserManagement userManagement = new();
            if (userManagement.GetSoundsSetting())
            {
                Console.Beep(700, 100);
                Console.Beep(700, 100);
                Console.Beep(700, 100);
            }
        }
        public static void InfoSound()
        {
            UserManagement userManagement = new();
            if (userManagement.GetSoundsSetting())
            {
                Console.Beep();
            }
        }
        public static void WelcomeSound()
        {
            UserManagement userManagement = new();
            if (userManagement.GetSoundsSetting())
            {
                Console.Beep(300, 250);
                Console.Beep(400, 250);
                Console.Beep(500, 250);
                Console.Beep(600, 300);
                Console.Beep(500, 250);
                Console.Beep(600, 500);
            }
        }
        public static void GoodbyeSound()
        {
            UserManagement userManagement = new();
            if (userManagement.GetSoundsSetting())
            {
                Console.Beep(600, 250);
                Console.Beep(600, 250);
                Console.Beep(500, 500);
            }
        }
    }
}