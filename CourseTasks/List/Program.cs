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
                linkedList.InsertElementToBeginning("Андрей");

                Console.WriteLine(linkedList);
                Console.WriteLine("Количество элементов: " + linkedList.Count);
                Console.WriteLine("Получим первый элемент: " + linkedList.GetFirstElementValue());
                Console.WriteLine("Получим элемент с индексом 3: " + linkedList.GetValueByIndex(3));

                linkedList.ChangeElementByIndex(3, "Вика");
                Console.WriteLine("Заменим элемент с индексом 3 на Вику, получим: " + linkedList);

                linkedList.DeleteItemByIndex(3);
                Console.WriteLine("Удалим элемент с индексом 3 получим: " + linkedList);

                linkedList.InsertElementByIndex(3, "Сергей");
                Console.WriteLine("Вставим элемент Сергей по индексу 3 получим: " + linkedList);

                linkedList.DeleteNodeByValue("Андрей");
                Console.WriteLine("Удалим элемент Андрей получим: " + linkedList);

                linkedList.DeleteFirstItem();
                Console.WriteLine("Удалим первый элемент получим: " + linkedList);

                linkedList.Reverse();
                Console.WriteLine("Развернем список получим: " + linkedList);

                linkedList.DeleteItemByIndex(0);
                Console.WriteLine("Удалим элемент с индексом 0 получим: " + linkedList);

                linkedList.InsertElementByIndex(0, "Сергей");
                Console.WriteLine("Вставим элемент Сергей по индексу 0 получим: " + linkedList);

                linkedList.AddToEnd("Андрей");
                Console.WriteLine("Вставим элемент Андрей в конец списка: " + linkedList);

                SinglyLinkedList<string> copyLinkedList = linkedList.Copy();

                Console.WriteLine("Скопируем список получим: " + copyLinkedList);
                Console.ReadKey();
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
