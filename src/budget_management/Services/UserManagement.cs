
using budget_management.Messages;
using System.Text.Json;
using Domain.Entities;

namespace budget_management.Services;
public class UserManagement
{
    private readonly FileManagement _fileManagement = new();
    public bool IsUserLoggedIn => !string.IsNullOrEmpty(FileManagement.LoggedUserID);

    public void RegisterUser()
    {
        Display.Logo(false);
        Console.WriteLine();
        Console.WriteLine("=== Rejestracja ===");
        Console.WriteLine();

        string id = Guid.NewGuid().ToString().Substring(0, 6);

        while (LoadUsers().ContainsKey(id))
        {
            id = Guid.NewGuid().ToString().Substring(0, 6);
        }

        Console.Write("Podaj nazwę wyświetlaną: ");
        string name = Console.ReadLine();
        Console.Write("Podaj nazwę, której chcesz używać do logowania: ");
        string nickname = Console.ReadLine();

        while (nickname.Length < 5)
        {
            Message.Warning("Nazwa logowania musi mieć co najmniej 5 znaków.");

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("\n");

            Console.Write("Podaj dłuższą nazwę logowania: ");
            nickname = Console.ReadLine();
        }

        while (LoadUsers().ContainsKey(nickname))
        {
            Message.Warning("Podana nazwa logowania jest już zajęta.");

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("\n");

            Console.Write("Podaj inną nazwę: ");
            nickname = Console.ReadLine();
        }

        Console.Write("Utwórz hasło: ");
        string password = Console.ReadLine();

        while (password.Length < 5)
        {
            Message.Warning("Hasło musi mieć co najmniej 5 znaków.");

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("\n");

            Console.Write("Podaj dłuższe hasło: ");
            password = Console.ReadLine();
        }

        //Console.Write("Podaj dzień wypłaty: ");
        //int payday = int.Parse(Console.ReadLine());
        Console.Write("Podaj miesięczny budżet: ");
        decimal monthBudget = decimal.Parse(Console.ReadLine());

        FileManagement.LoggedUserID = id;
        _fileManagement.CreatePersonalFiles();

        var config = new Dictionary<string, object>
        {
            { "Currency", "PLN" },
            { "MonthBudget", monthBudget },
            //{ "Payday", payday },
            { "Sounds", true }
        };

        _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);

        var person = new Person(id, name, nickname);
        var users = LoadUsers();

        users[nickname] = new UserData
        {
            Person = person,
            Password = password
        };

        SaveUsers(users);

        FileManagement.LoggedUserID = string.Empty;
        Message.Info("Rejestracja zakończona pomyślnie!");
    }

    public Person LoginUser()
    {
        Display.Logo(false);
        Console.WriteLine();
        Console.WriteLine("=== Logowanie ===");
        Console.WriteLine();

        Console.Write("Podaj swój login: ");
        string nickname = Console.ReadLine();
        Console.Write("Podaj hasło: ");
        string password = Console.ReadLine();

        var users = LoadUsers();

        if (users.TryGetValue(nickname, out UserData userData) && userData.Password == password)
        {
            Message.Info(InfoMessage.LoginSuccesfull());

            FileManagement.LoggedUserID = userData.Person.ID;
            Message.LoggedUserName = userData.Person.Name;

            return userData.Person;
        }
        else
        {
            Message.Error(ErrorMessage.LoginFail());
            return null;
        }
    }

    public void LogoutUser()
    {
        FileManagement.LoggedUserID = string.Empty;
        Message.Info("Użytkownik został wylogowany");
        Console.WriteLine();
    }

    public void ChangePassword()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Zmiana hasła ===");
        Console.WriteLine();

        Console.Write("Podaj swoją nazwę logowania: ");
        string name = Console.ReadLine();
        Console.Write("Podaj obecne hasło: ");
        string currentPassword = Console.ReadLine();

        var users = LoadUsers();

        if (users.TryGetValue(name, out UserData userData))
        {
            if (userData.Password == currentPassword)
            {
                Console.Write("Podaj nowe hasło: ");
                string newPassword = Console.ReadLine();
                userData.Password = newPassword;
                while (currentPassword == newPassword)
                {
                    Message.Warning(WarningMessage.SamePassword());
                    Console.Write("Podaj nowe hasło: ");
                    newPassword = Console.ReadLine();
                }
                SaveUsers(users);
                Console.WriteLine("Hasło zostało zmienione.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowe obecne hasło.");
            }
        }
        else
        {
            Console.WriteLine("Użytkownik nie istnieje.");
        }
    }

    public void ChangeName()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Zmiana nazwy wyświetlanej ===");
        Console.WriteLine();
        Console.Write("Podaj swoją nazwę logowania: ");
        string name = Console.ReadLine();
        Console.Write("Podaj swoje hasło: ");
        string password = Console.ReadLine();

        var users = LoadUsers();

        if (users.TryGetValue(name, out UserData userData) && userData.Password == password)
        {
            Console.Write("Podaj nową nazwę wyświetlaną: ");
            string newName = Console.ReadLine();
            userData.Person.Name = newName;
            SaveUsers(users);
            Console.WriteLine();
            Message.Info("Nazwa wyświetlana została zmieniona.\nZmiana będzie widoczna po ponownym zalogowaniu.");
        }
        else
        {
            Message.Error(ErrorMessage.LoginFail());
        }
    }

    public void DeleteUser()
    {
        Display.Logo();
        Console.WriteLine();
        Message.Warning(WarningMessage.DeleteFiles());

        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write("\n");

        Console.Write("Wpisz TAK, aby potwierdzić, w przeciwnym razie operacja zostanie anulowana");
        Console.WriteLine();
        Console.Write("Potwierdzenie: ");

        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
        {
            case "TAK":
                Console.Write("Podaj swoją nazwę logowania: ");
                string name = Console.ReadLine();
                Console.Write("Podaj swoje hasło: ");
                string password = Console.ReadLine();

                var users = LoadUsers();

                if (users.TryGetValue(name, out UserData userData) && userData.Password == password)
                {
                    File.Delete(FileManagement.ConfigFilePath);
                    File.Delete(FileManagement.TransactionsFilePath);
                    users.Remove(name);
                    SaveUsers(users);

                    FileManagement.LoggedUserID = string.Empty;

                    Message.Info("Konto zostało usunięte.");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe dane.");
                    Message.Info("Nie usunięto konta.");
                }

                break;

            default:
                Message.Info("Nie usunięto konta.");
                break;
        }
    }

    private Dictionary<string, UserData> LoadUsers()
    {
        if (!File.Exists(FileManagement.UsersFilePath))
        {
            return new Dictionary<string, UserData>();
        }

        string json = File.ReadAllText(FileManagement.UsersFilePath);
        return JsonSerializer.Deserialize<Dictionary<string, UserData>>(json) ?? new Dictionary<string, UserData>();
    }

    private void SaveUsers(Dictionary<string, UserData> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileManagement.UsersFilePath, json);
    }

    public class UserData
    {
        public Person Person { get; set; }
        public string Password { get; set; }
    }

    //public void SetPayday()
    //{
    //    Console.Write("Podaj dzień wypłaty (1-31): ");
    //    int payday = int.Parse(Console.ReadLine());

    //    var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigFilePath) ?? new Dictionary<string, object>();
    //    config["Payday"] = payday;
    //    _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);

    //    Console.WriteLine("Dzień wypłaty został ustawiony.");
    //}

    public bool GetSoundsSetting()
    {
        if (!File.Exists(FileManagement.ConfigFilePath))
        {
            return false;
        }
        string jsonContent = File.ReadAllText(FileManagement.ConfigFilePath);
        Config config = JsonSerializer.Deserialize<Config>(jsonContent);

        return config.Sounds;
    }
    public void SetSounds()
    {
        var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigFilePath) ?? new Dictionary<string, object>();
        bool sounds = GetSoundsSetting();

        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Zmiana ustawień dźwięku ===");
        Console.WriteLine();
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
