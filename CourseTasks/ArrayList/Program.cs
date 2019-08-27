using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                МyList<string> myList = new МyList<string>();
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

                myList.Insert(0, "тополь");
                Console.WriteLine("Вставим тополь по индексу 0 получим: " + myList);

                myList.Remove("акация");
                Console.WriteLine("Удалим акация получим: " + myList);

                myList.RemoveAt(2);
                Console.WriteLine("Удалим элемент по индексу 2 получим: " + myList);

                Console.WriteLine("Проверка на вхождение элемента  null = " + myList.Contains(null));
                Console.WriteLine("Проверка на вхождение элемента  липа = " + myList.Contains("липа"));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (ArgumentNullException e)
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
