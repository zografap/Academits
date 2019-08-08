using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string> { };
            Console.WriteLine("Прочитаем в список все строки из файла");

            try
            {
                using (StreamReader reader = new StreamReader("C:\\Users\\хп\\source\\repos\\Academits1\\CourseTasks\\ArrayListHome\\TextFile1.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка при работе с файлом");
            }

            Console.WriteLine("Получим: ");
            Console.Write("{ ");

            foreach (string s in lines)
            {
                Console.Write(s + ", ");
            }

            Console.Write("}");
            Console.WriteLine();

            List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 5, 77, 10, 20 };
            Console.Write("Список list1: { ");

            foreach (int n in list1)
            {
                Console.Write(n + ", ");
            }

            Console.Write("}");

            Console.WriteLine("Удалим четные числа из списка");

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] % 2 == 0)
                {
                    list1.RemoveAt(i);
                    i--;
                }
            }

            Console.Write("Получим: ");
            Console.Write("{ ");

            foreach (int n in list1)
            {
                Console.Write(n + ", ");
            }

            Console.Write("}");

            Console.WriteLine();
            List<int> list2 = new List<int> { 1, 2, 3, 2, 5, 5, 7, 1, 5 };
            Console.Write("Список list2: { ");

            foreach (int n in list2)
            {
                Console.Write(n + ", ");
            }

            Console.Write("}");

            Console.WriteLine();
            Console.WriteLine("Создадим новый список без повторений");
            List<int> list3 = new List<int>();

            foreach (int n in list2)
            {
                if (!list3.Contains(n))
                {
                    list3.Add(n);
                }
            }

            Console.Write("Список list3: { ");

            foreach (int n in list3)
            {
                Console.Write(n + ", ");
            }

            Console.Write("}");
            Console.ReadKey();
        }
    }
}



