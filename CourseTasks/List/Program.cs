using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SinglyLinkedList<string> linkedList = new SinglyLinkedList<string>();

                linkedList.InsertElementToBeginning("Светлана");
                linkedList.InsertElementToBeginning("Василий");
                linkedList.InsertElementToBeginning("Игорь");
                linkedList.InsertElementToBeginning("Ольга");
                linkedList.InsertElementToBeginning("Роман");

                Console.WriteLine(linkedList);

                Console.WriteLine("Количество элементов: " + linkedList.GetSize());
                Console.WriteLine("Получим первый элемент: " + linkedList.GetValueFirstElement());
                Console.WriteLine("Получим элемент с индексом 3: " + linkedList.GetValueByIndex(3));

                linkedList.ChangeElementByIndex(3, "Вика");
                Console.WriteLine("Заменим элемент с индексом 3 на Вику, получим: " + linkedList);

                linkedList.DeleteItemByIndex(3);
                Console.WriteLine("Удалим элемент с индексом 3 получим: " + linkedList);

                linkedList.InsertElementByIndex("Сергей", 3);
                Console.WriteLine("Вставим элемент Сергей по индексу 3 получим: " + linkedList);

                linkedList.DeleteNodeByValue("Роман");
                Console.WriteLine("Удалим элемент Роман получим: " + linkedList);

                linkedList.DeleteFirstItem();
                Console.WriteLine("Удалим первый элемент получим: " + linkedList);

                linkedList.Reverse();
                Console.WriteLine("Развернем список получим: " + linkedList);

                SinglyLinkedList<string> copylinkedList = linkedList.Сopy();
                Console.WriteLine("Скопируем список получим: " + copylinkedList);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
