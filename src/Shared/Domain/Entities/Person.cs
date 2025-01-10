
namespace Domain.Entities
{
    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }

        public Person(string id, string name, string nickname)
        {
            ID = id;
            Name = name;
            Nickname = nickname;
        }
    }
}
