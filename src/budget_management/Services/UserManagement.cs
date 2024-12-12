
using budget_management.Messages;
using System.Text.Json;
using Domain.Entities;

namespace budget_management.Services;
public class UserManagement
{
    private readonly FileManagement _fileManagement = new();

    public void SetPayday()
    {
        Console.Write("Podaj dzień wypłaty (1-31): ");
        int payday = int.Parse(Console.ReadLine());

        var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigFilePath) ?? new Dictionary<string, object>();
        config["Payday"] = payday;
        _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);

        Console.WriteLine("Dzień wypłaty został ustawiony.");
    }

    public bool GetSoundsSetting()
    {
        string jsonContent = File.ReadAllText(FileManagement.ConfigFilePath);

        Config config = JsonSerializer.Deserialize<Config>(jsonContent);

        return config.Sounds;
    }
    public void SetSounds()
    {
        var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigFilePath) ?? new Dictionary<string, object>();
        bool sounds = GetSoundsSetting();

        Console.Write("Dźwięki programu są obecnie ");
        if (sounds == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("włączone");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("wyłączone");
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine();
        Console.WriteLine("Czy chcesz zmienić to ustawienie? (tak/nie): ");
        string choice = Console.ReadLine().ToLower();

        if (choice == "tak")
        {
            sounds = !sounds;
            config["Sounds"] = sounds;
            _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);
            Console.WriteLine("Zmieniono ustawienie dźwięków.");
        }
        else if (choice == "nie")
        {
            Console.WriteLine("Nie zmieniono ustawienia dźwięków.");
        }
        else
        {
            Message.Error(ErrorMessage.InvalidChoice());
        }
    }
}
