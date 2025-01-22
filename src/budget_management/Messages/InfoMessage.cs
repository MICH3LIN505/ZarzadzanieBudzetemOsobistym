using System.Globalization;

namespace budget_management.Messages;

public static class InfoMessage
{
    public static string Welcome() => "Witaj w programie do zarządzania budżetem osobistym!" +
        "\nZaloguj się, aby kontynuować";
    public static string WelcomeUser(decimal Balance) => $"Witaj, {Message.LoggedUserName}! Twój aktualny bilans wynosi {Balance} {TransactionMessage.Currency()}";
    public static string PressAnyKey() => "Naciśnij dowolny klawisz, aby kontynuować...";
    public static string ChooseOption() => "Wybierz opcję: ";
    public static string SayYesToConfirm() => "Wpisz \"tak\", aby potwierdzić, w przeciwnym razie operacja zostanie anulowana: ";
    public static string Confirmation() => "Potwierdzenie: ";
    public static string OperationCancelled() => "Operacja anulowana";
    public static string ProgramWillBeClosed() => "Program zostanie zamknięty w celu zastosowania zmian";
    public static string LoginSuccesfull() => "Zalogowano pomyślnie";
    public static string LogoutSuccesfull() => "Wylogowano pomyślnie";
    public static string EnterNewPassword() => "Podaj nowe hasło: ";
    public static string PasswordChanged() => "Hasło zostało zmienione";
    public static string AccountCreated() => "Konto zostało utworzone";
    public static string AccountDeleted() => "Konto zostało usunięte";
    public static string Credits() => "Created by Michał Sidzina (and a pinch of ChatGPT)";
    public static string Goodbye() => "Lambert, ty... to znaczy bywaj!";
}