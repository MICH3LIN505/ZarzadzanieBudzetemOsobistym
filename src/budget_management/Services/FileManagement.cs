
using budget_management.Messages;
using budget_management.Sounds;
using System.Text.Json;
namespace budget_management.Services;

public class FileManagement
{
    private static string ConfigDirectory => $@"C:\Users\{Environment.UserName}\Desktop\";
    public static string LoggedUserID { get; set; } = string.Empty;
    public static string ConfigFilePath => Path.Combine(ConfigDirectory, $"{LoggedUserID}_config.json");
    public static string TransactionsFilePath => Path.Combine(ConfigDirectory, $"{LoggedUserID}_transactions.json");
    public static string UsersFilePath => Path.Combine(ConfigDirectory, "users.json");

    public void CreateUsersFile()
    {
        try
        {
            if (!File.Exists(UsersFilePath))
            {
                File.WriteAllText(UsersFilePath, "{}");
                Console.WriteLine("Utworzono plik users.json.");
            }
            else
            {
                Console.WriteLine("Plik users.json już istnieje.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas tworzenia plików: {ex.Message}");
        }
    }

    public void CreatePersonalFiles()
    {
        try
        {
            if (!File.Exists(ConfigFilePath))
            {
                var defaultConfig = new { Currency = "PLN", MonthBudget = 0, Payday = 1, Sounds = true };
                string configJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigFilePath, configJson);
            }
            else
            {
                Console.WriteLine("Plik config.json już istnieje.");
            }

            if (!File.Exists(TransactionsFilePath))
            {
                File.WriteAllText(TransactionsFilePath, "[]");
                Console.WriteLine("Utworzono plik transactions.json.");
            }
            else
            {
                Console.WriteLine("Plik transactions.json już istnieje.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas tworzenia plików: {ex.Message}");
        }
    }

    public void SaveToFile(string path, object data)
    {
        string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, jsonData);
    }

    public T? ReadFromFile<T>(string path)
    {
        string jsonData = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(jsonData);
    }

    public void DeleteFiles()
    {
        Display.Logo();
        Console.WriteLine();
        Message.Warning(WarningMessage.DeleteFiles());
        Console.WriteLine();
        Console.Write("Wpisz TAK, aby potwierdzić, w przeciwnym razie operacja zostanie anulowana");
        Console.WriteLine();
        Console.Write("Potwierdzenie: ");

        string deletionChoice;

        deletionChoice = Console.ReadLine();
        if (deletionChoice == "TAK")
        {
            Console.WriteLine();
            Message.Info(InfoMessage.ProgramWillBeClosed());
            InfoMessage.PressAnyKey();
            Console.ReadKey();
            ExitProcedure(true);
        }
        else
        {
            Console.WriteLine();
            Message.Info(InfoMessage.OperationCancelled());
        }
    }

    public static void ExitProcedure(bool deletionRequest)
    {
        Console.Clear();
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("Created by Michał Sidzina (and a pinch of ChatGPT)");
        Console.WriteLine();
        Console.WriteLine(InfoMessage.Goodbye());
        Console.WriteLine();

        Sound.GoodbyeSound();

        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();

        if (deletionRequest)
        {
            File.Delete(ConfigFilePath);
            File.Delete(TransactionsFilePath);
        }
        Environment.Exit(0);
    }
}