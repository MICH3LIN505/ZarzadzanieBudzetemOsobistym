namespace budget_management.Messages
{
    public static class UserMessage
    {
        public static string LoginHeader() => "=== Logowanie ===";
        public static string RegisterHeader() => "=== Rejestracja ===";
        public static string ChangePasswordHeader() => "=== Zmiana hasła ===";
        public static string ChangeNameHeader() => "=== Zmiana nazwy wyświetlanej ===";
        public static string SoundsHeader() => "=== Zmiana ustawień dźwięku ===";
        public static string Name() => "Podaj nazwę wyświetlaną: ";
        public static string Nickname() => "Podaj nazwę, której chcesz używać do logowania: ";
        public static string NicknameTooShort() => "Nazwa logowania musi mieć co najmniej 5 znaków";
        public static string LongerNickname() => "Podaj dłuższą nazwę logowania: ";
        public static string NicknameTaken() => "Podana nazwa logowania jest już zajęta";
        public static string MakeAnotherNickname() => "Podaj inną nazwę logowania: ";
        public static string MakePassword() => "Utwórz hasło: ";
        public static string PasswordTooShort() => "Hasło musi mieć co najmniej 5 znaków";
        public static string LongerPassword() => "Podaj dłuższe hasło: ";
        public static string SetNewPassword() => "Podaj nowe hasło: ";
        public static string PasswordRepeat() => "Powtórz hasło: ";
        public static string PasswordChanged() => "Hasło zostało zmienione";
        public static string PasswordsNotMatch() => "Podane hasła nie są takie same";
        public static string UserExists() => "Użytkownik o podanej nazwie już istnieje";
        public static string RegisterSuccess() => "Użytkownik został zarejestrowany";
        public static string LoginName() => "Podaj nazwę logowania: ";
        public static string Password() => "Podaj hasło: ";
        public static string LoginFail() => "Nieprawidłowa nazwa użytkownika lub hasło";
        public static string SetNewName() => "Podaj nową nazwę wyświetlaną: ";
        public static string NameChanged() => "Nazwa wyświetlana została zmieniona.\nZmiana będzie widoczna po ponownym zalogowaniu.";
        public static string UserDeleted() => "Konto użytkownika zostało usunięte";
        public static string UserNotDeleted() => "Konto nie zostało usunięte";
        public static string SoundsCurrently() => "Dźwięki programu są obecnie ";
        public static string Enabled() => "włączone";
        public static string Disabled() => "wyłączone";
        public static string WannaChange() => "Czy chcesz zmienić to ustawienie? (tak/nie): ";
        public static string SoundSettingChanged() => "Zmieniono ustawienie dźwięków.";
        public static string SoundsSettingNotChanged() => "Nie zmieniono ustawienia dźwięków.";
    }
}
