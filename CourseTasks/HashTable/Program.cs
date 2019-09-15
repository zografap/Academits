using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HashTable<string> wood = new HashTable<string>();

                wood.Add("береза");
                wood.Add("осина");
                wood.Add("сосна");
                wood.Add("ель");
                wood.Add("рябина");
                wood.Add("ольха");
                wood.Add("дуб");
                wood.Add("бук");
                wood.Add("липа");
                wood.Add("акация");

                Console.WriteLine(wood);
                Console.WriteLine("количество элементов =" + wood.Count);

                Console.WriteLine("Проверим на наличие элемента акация: " + wood.Contains("акация"));
                Console.WriteLine("Проверим на наличие элемента пихта: " + wood.Contains("пихта"));

                string[] arrayWood = new string[10];
                wood.CopyTo(arrayWood, 0);
                Console.WriteLine("Скопируем таблицу в массив получим: ");

                foreach (string e in arrayWood)
                {
                    Console.WriteLine(e);
                }

                wood.Remove("липа");
                Console.WriteLine("Удалим элемент липа получим: " + Environment.NewLine + wood);

                wood.Clear();
                Console.WriteLine("Очистим таблицу получим: " + wood);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (ArgumentException e)
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
