
using budget_management.Messages;
using budget_management.Sounds;
using System.Text.Json;
namespace budget_management.Services;

public class FileManagement
{
    private static string ConfigDirectory => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string LoggedUserID { get; set; } = string.Empty;
    public static string ConfigFilePath => Path.Combine(ConfigDirectory, $"{LoggedUserID}_config.json");
    public static string TransactionsFilePath => Path.Combine(ConfigDirectory, $"{LoggedUserID}_transactions.json");
    public static string UsersFilePath => Path.Combine(ConfigDirectory, "users.json");

    public void CreateUsersFile()
    {
        if (!File.Exists(UsersFilePath))
        {
            File.WriteAllText(UsersFilePath, "{}");
        }
    }

    public void CreatePersonalFiles()
    {
        if (!File.Exists(ConfigFilePath))
        {
            var defaultConfig = new { MonthBudget = 0, Sounds = true };
            string configJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFilePath, configJson);
        }

        if (!File.Exists(TransactionsFilePath))
        {
            File.WriteAllText(TransactionsFilePath, "[]");
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

    public void ExitProcedure(bool LogoColor = true)
    {
        Console.Clear();
        Display.Logo(LogoColor);
        Console.WriteLine();
        Console.WriteLine(InfoMessage.Credits());
        Console.WriteLine();
        Console.WriteLine(InfoMessage.Goodbye());
        Console.WriteLine();

        Sound.GoodbyeSound();

        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();

        Environment.Exit(0);
    }
}