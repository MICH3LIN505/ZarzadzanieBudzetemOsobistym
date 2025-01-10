namespace budget_management.Messages;

public static class WarningMessage
{
    public static string FileNotFound() => "Nie znaleziono pliku";
    public static string DeleteFiles() => "Uwaga!" +
        "\nCzy na pewno chcesz usunąć profil użytkownika wraz z wszystkimi powiązanymi danymi?" +
        "\nOperacja jest nieodwracalna!";
    public static string SamePassword() => "Nowe hasło nie może być takie samo jak obecne.";
}
