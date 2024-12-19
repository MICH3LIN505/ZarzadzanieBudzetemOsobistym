namespace budget_management.Messages;

public static class InfoMessage
{
    public static string Welcome() => $"Witaj, {Message.LoggedUserName}! Twój aktualny bilans wynosi {Message.Bilance}";
    public static string PressAnyKey() => "Naciśnij dowolny klawisz, aby kontynuować...";
    public static string ChooseOption() => "Wybierz opcję" + ": ";
    public static string OperationCancelled() => "Operacja anulowana";
    public static string FilesDeleted() => "Pliki zapisu i ustawień zostały usunięte";
    public static string ProgramWillBeClosed() => "Program zostanie zamknięty w celu zastosowania zmian";
    public static string Goodbye() => "Lambert, ty... to znaczy bywaj!";
}