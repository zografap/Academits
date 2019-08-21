using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            МyList<string> myList = new МyList<string>(10);
            myList.Add("береза");
            myList.Add("осина");
            myList.Add("сосна");
            myList.Add("ель");
            myList.Add("рябина");
            myList.Add("ольха");
            myList.Add("дуб");
            myList.Add("бук");
            myList.Add("липа");
            myList.Add("акация");

            Console.WriteLine("Список: " + myList);

            myList.EnsureCapacity(15);

            myList.Insert(5,"тополь");
            Console.WriteLine("Вставим тополь по индексу 5 получим: " + myList);

            myList.Remove("тополь");
            Console.WriteLine("Удалим тополь получим: " + myList);

            myList.RemoveAt(2);
            Console.WriteLine("Удалим элемент по индексу 2 получим: " + myList);

            Console.ReadKey();
        }
    }
}
