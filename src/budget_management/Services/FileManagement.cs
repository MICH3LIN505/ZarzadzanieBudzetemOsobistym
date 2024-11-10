//funkcje służące do zarządzania plikami

namespace budget_management.Services;
using budget_management.Messages;
using System.IO;
public class FileManagement
{
    Info Info = new();
    Error Error = new();
    public void CreateNewFile()
    {
        string filePath = @"C:\Users\micha\Desktop\budget.txt";

        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine("This is the budget file. DO NOT modify it manually unless you know what you are doing!");
            }
            Info.FileCreated();
        }
    }
    public void SaveToFile()
    {

        Info.FileSaved();
    }

    public void ReadFromFile()
    {

        Info.ReadFromFile();
    }

    public void DeleteFile()
    {
        string fileName = "budget.txt";

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        else
        {
            Error.FileExists();
        }
    }
}
