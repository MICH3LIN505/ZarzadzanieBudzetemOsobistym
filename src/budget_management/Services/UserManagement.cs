//metody do zarządzania danymi użytkowników

namespace budget_management.Services;
using Domain.Entities;
public class UserManagement
{
    public void SetPayday()
    {
        Console.WriteLine("Podaj dzień wypłaty: ");
        string payday = Console.ReadLine();
        //Person.Payday = payday;
    }
}