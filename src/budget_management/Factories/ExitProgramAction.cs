using budget_management.Services;
namespace budget_management.Factories;

public class ExitProgramAction : IMenuAction
{
    public void Execute()
    {
        FileManagement fileManagement = new();
        fileManagement.ExitProcedure();
    }
}
