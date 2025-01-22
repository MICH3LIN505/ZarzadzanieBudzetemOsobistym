namespace budget_management.Messages;

public static class ErrorMessage
{
    public static string InvalidValue() => "Podano nieprawidłową wartość. Spróbuj ponownie";
    public static string LoginFail() => "Nieprawidłowa nazwa użytkownika lub hasło";
}
