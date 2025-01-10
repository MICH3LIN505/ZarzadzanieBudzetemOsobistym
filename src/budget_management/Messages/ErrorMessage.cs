﻿namespace budget_management.Messages;

public static class ErrorMessage
{
    public static string InvalidChoice() => "Nieprawidłowy wybór";
    public static string FileExists() => "Plik już istnieje";
    public static string LoginFail() => "Użytkownik nie istnieje lub hasło jest nieprawidłowe";
}
