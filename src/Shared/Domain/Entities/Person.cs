using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Person
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? Nickname { get; set; }

        public Person(string name, string surname, string nickname)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
        }
    }
}
