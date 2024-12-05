
namespace budget_management.Services;
public class UserManagement
{
    private readonly FileManagement _fileManagement = new();

    public void SetPayday()
    {
        Console.WriteLine("Podaj dzień wypłaty (1-31):");
        int payday = int.Parse(Console.ReadLine());

        var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigPath) ?? new Dictionary<string, object>();
        config["Payday"] = payday;
        _fileManagement.SaveToFile(FileManagement.ConfigPath, config);

        Console.WriteLine("Dzień wypłaty został ustawiony.");
    }
}
