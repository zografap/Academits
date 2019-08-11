using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<string> linkedList = new SinglyLinkedList<string>();
            
            linkedList.InsertElementToBeginning("Светлана");
            linkedList.InsertElementToBeginning("Василий");
            linkedList.InsertElementToBeginning("Игорь");
            linkedList.InsertElementToBeginning("Ольга");
            linkedList.InsertElementToBeginning("Роман");
            
            Console.WriteLine(linkedList.ToString());

            Console.WriteLine("Количество элементов: " + linkedList.GetSize());
            Console.WriteLine("Получим первый элемент: " + linkedList.GetValueFirstElement().Data);
            Console.WriteLine("Получим элемент с индексом 3: " + linkedList.GetValueByIndex(3).Data);
            linkedList.ChangeElementByIndex(3,"Вика");
            Console.WriteLine("Заменим элемент с индексом 3 на Вику, получим: " + linkedList.ToString());
            Console.ReadKey();
        }
    }
}
