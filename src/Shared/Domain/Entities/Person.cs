
namespace Domain.Entities
{
    public class Person
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string Payday { get; set; }
        public decimal MonthBudget { get; set; }

        public Person(string name, string surname, string payday, decimal monthBudget)
        {
            Name = name;
            Surname = surname;
            Payday = payday;
            MonthBudget = monthBudget;
        }
    }
}
