using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class MyHashTable
    {
        private List<Person> ListPerson = new List<Person> { };

        private int length;

        private List<Person>[] PeopleArray = new List<Person>[10];

        public MyHashTable()
        {
            PeopleArray = new List<Person>[10];
        }

        public void Insert(Person person)
        {
            int index = Math.Abs(person.GetHashCode() % PeopleArray.Length);

            if (PeopleArray[index] == null)
            {
                PeopleArray[index] = new List<Person> { person };
            }
            else
            {
                if (PeopleArray[index].IndexOf(person) == -1)
                {
                    PeopleArray[index].Add(person);
                }
                else
                {
                    throw new ArgumentException("Хеш-таблица уже содержит такого человека");
                }
            }
        }





    }
}
