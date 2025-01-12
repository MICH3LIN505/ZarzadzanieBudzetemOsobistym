using budget_management.Services;
namespace budget_management.Factories;

public sealed class DeleteFilesAction : IMenuAction
{
    private readonly FileManagement _fileManagement;

    public DeleteFilesAction(FileManagement fileManagement)
    {
        _fileManagement = fileManagement;
    }

    public void Execute()
    {
        UserManagement userManagement = new();
        userManagement.DeleteUser();
    }
}
