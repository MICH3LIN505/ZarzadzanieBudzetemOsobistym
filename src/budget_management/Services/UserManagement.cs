
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
        Console.WriteLine(UserMessage.RegisterHeader());
        Console.WriteLine();

        string id = Guid.NewGuid().ToString().Substring(0, 6);

        while (LoadUsers().ContainsKey(id))
        {
            id = Guid.NewGuid().ToString().Substring(0, 6);
        }

        Console.Write(UserMessage.Name());
        string name = Value.ReadString();

        Console.Write(UserMessage.Nickname());
        string nickname = Value.ReadString();

        while (nickname.Length < 5)
        {
            Message.Warning(UserMessage.NicknameTooShort());

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("\n");

            Console.Write(UserMessage.LongerNickname());
            nickname = Value.ReadString();
        }

        while (LoadUsers().ContainsKey(nickname))
        {
            Message.Warning(UserMessage.NicknameTaken());

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("\n");

            Console.Write(UserMessage.MakeAnotherNickname());
            nickname = Value.ReadString();
        }

        string password = ".";
        string passwordRepeat = ",";

        while (password != passwordRepeat)
        {
            Console.Write(UserMessage.MakePassword());
            password = Value.ReadString();

            while (password.Length < 5)
            {
                Message.Warning(UserMessage.PasswordTooShort());

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("\n");

                Console.Write(UserMessage.LongerPassword());
                password = Value.ReadString();
            }

            Console.Write(UserMessage.PasswordRepeat());
            passwordRepeat = Value.ReadString();

            if (password != passwordRepeat)
                Message.Warning(UserMessage.PasswordsNotMatch());
        }

        Console.Write(TransactionMessage.SetNewBudget());
        decimal monthBudget = Value.ReadDecimal();

        FileManagement.LoggedUserID = id;
        _fileManagement.CreatePersonalFiles();

        var config = new Dictionary<string, object>
        {
            { "MonthBudget", monthBudget },
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
        Message.Info(UserMessage.RegisterSuccess());
    }

    public Person LoginUser()
    {
        Display.Logo(false);
        Console.WriteLine();
        Console.WriteLine(UserMessage.LoginHeader());
        Console.WriteLine();

        Console.Write(UserMessage.LoginName());
        string nickname = Value.ReadString();

        Console.Write(UserMessage.Password());
        string password = Value.ReadString();

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
        Message.Info(InfoMessage.LogoutSuccesfull());
        Console.WriteLine();
    }

    public void ChangePassword()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(UserMessage.ChangePasswordHeader());
        Console.WriteLine();

        Console.Write(UserMessage.LoginName());
        string name = Value.ReadString();

        Console.Write(UserMessage.Password());
        string currentPassword = Value.ReadString();

        var users = LoadUsers();

        if (users.TryGetValue(name, out UserData userData))
        {
            if (userData.Password == currentPassword)
            {
                string newPassword = ".";
                string passwordRepeat = ",";

                do
                {
                    Console.Write(UserMessage.SetNewPassword());
                    newPassword = Value.ReadString();

                    while (currentPassword == newPassword)
                    {
                        Message.Warning(WarningMessage.SamePassword());
                        Console.Write(UserMessage.SetNewPassword());
                        newPassword = Value.ReadString();
                    }

                    Console.Write(UserMessage.PasswordRepeat());
                    passwordRepeat = Value.ReadString();

                    if (newPassword != passwordRepeat)
                        Message.Warning(UserMessage.PasswordsNotMatch());
                }
                while (newPassword != passwordRepeat);

                userData.Password = newPassword;
                SaveUsers(users);
                Message.Info(UserMessage.PasswordChanged());
            }
            else
            {
                Message.Error(UserMessage.LoginFail());
            }
        }
        else
        {
            Console.WriteLine(UserMessage.LoginFail());
        }
    }

    public void ChangeName()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(UserMessage.ChangeNameHeader());
        Console.WriteLine();

        Console.Write(UserMessage.LoginName());
        string name = Value.ReadString();

        Console.Write(UserMessage.Password());
        string password = Value.ReadString();

        var users = LoadUsers();

        if (users.TryGetValue(name, out UserData userData) && userData.Password == password)
        {
            Console.Write(UserMessage.SetNewName());
            string newName = Value.ReadString();
            userData.Person.Name = newName;
            
            SaveUsers(users);
            Console.WriteLine();
            Message.Info(UserMessage.NameChanged());
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
        Console.WriteLine();

        Console.Write(InfoMessage.SayYesToConfirm());
        Console.WriteLine();
        Console.Write(InfoMessage.Confirmation());

        string choice = Value.ReadString();
        Console.WriteLine();

        switch (choice)
        {
            case Decision.VeryAffirmative:

                Console.Write(UserMessage.LoginName());
                string name = Value.ReadString();

                Console.Write(UserMessage.Password());
                string password = Value.ReadString();

                var users = LoadUsers();

                if (users.TryGetValue(name, out UserData userData) && userData.Password == password)
                {
                    File.Delete(FileManagement.ConfigFilePath);
                    File.Delete(FileManagement.TransactionsFilePath);
                    users.Remove(name);
                    SaveUsers(users);

                    FileManagement.LoggedUserID = string.Empty;

                    Message.Info(UserMessage.UserDeleted());
                }
                else
                {
                    Message.Error(UserMessage.LoginFail());
                    Message.Info(UserMessage.UserNotDeleted());
                }

                break;

            default:
                Message.Info(UserMessage.UserNotDeleted());
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
        Console.WriteLine(UserMessage.SoundsHeader());
        Console.WriteLine();
        Console.Write(UserMessage.SoundsCurrently());

        if (sounds == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(UserMessage.Enabled());
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(UserMessage.Disabled());
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine();
        Console.Write(UserMessage.WannaChange());

        string choice = Value.ReadString().ToLower();

        if (choice == Decision.Affirmative)
        {
            sounds = !sounds;
            config["Sounds"] = sounds;
            _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);
            Message.Info(UserMessage.SoundSettingChanged());
        }
        else if (choice == Decision.Negative)
        {
            Message.Info(UserMessage.SoundsSettingNotChanged());
        }
        else
        {
            Message.Error(ErrorMessage.InvalidValue());
        }
    }
}
