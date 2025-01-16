namespace budget_management.Messages;

public static class WarningMessage
{
    public static string FileNotFound() => "Nie znaleziono pliku";
    public static string DeleteFiles() => "Uwaga!" +
        "\nZa chwilę usuniesz swój profil użytkownika wraz ze wszystkimi powiązanymi danymi." +
        "\nOperacja ta jest nieodwracalna!";
    public static string SamePassword() => "Nowe hasło nie może być takie samo jak obecne.";
}
