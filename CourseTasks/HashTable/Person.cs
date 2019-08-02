using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Person
    {
        private string Surname { get; set; }
        private string Name { get; set; }
        private string Phone { get; set; }

        public Person(string surname, string name, string phone)
        {
            if (surname == "" || name == "" || phone == "")
            {
                throw new ArgumentException("поля не должны быть пустыми");
            }

            Surname = surname;
            Name = name;
            Phone = phone;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + Surname.GetHashCode();
            hash = prime * hash + Name.GetHashCode();
            hash = prime * hash + Phone.GetHashCode();

            return hash;
        }
    }
}
