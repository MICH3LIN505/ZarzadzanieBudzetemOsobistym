
using System.Text.Json;
namespace budget_management.Services;

public class FileManagement
{
    public const string ConfigPath = @"C:\Users\micha\Desktop\ZarzadzanieBudzetem\config.json";
    public const string TransactionsPath = @"C:\Users\micha\Desktop\ZarzadzanieBudzetem\transactions.json";

    public void CreateFile()
    {
        try
        {
            // Tworzenie pliku config.json z domyślnymi wartościami
            if (!File.Exists(ConfigPath))
            {
                var defaultConfig = new { MonthBudget = 0, Payday = 1, Sounds = 1 };
                string configJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigPath, configJson);
                Console.WriteLine("Utworzono plik config.json z domyślnymi wartościami.");
            }
            else
            {
                Console.WriteLine("Plik config.json już istnieje.");
            }

            // Tworzenie pustego pliku transactions.json
            if (!File.Exists(TransactionsPath))
            {
                File.WriteAllText(TransactionsPath, "[]"); // Tworzy pustą listę w formacie JSON
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
        if (!File.Exists(path))
            return default;

        string jsonData = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(jsonData);
    }

    public void DeleteFile()
    {
        if (File.Exists(ConfigPath)) File.Delete(ConfigPath);
        if (File.Exists(TransactionsPath)) File.Delete(TransactionsPath);
        Console.WriteLine("Pliki zostały usunięte.");
    }
}