using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double[] array1 = { 1, 1, 1, 5, 10, 15 };
                double[] array2 = { 1, 1, 1 };

                Vector v1 = new Vector(array1);
                Vector v2 = new Vector(array2);
                Vector v4 = new Vector(10, array1);

                Console.WriteLine("Вектор v1:" + v1.ToString());
                Console.WriteLine("Вектор v2:" + v2.ToString());
                Console.WriteLine("Вектор v3:" + v4.ToString());

                v1.Add(v2);
                Console.WriteLine("Сумма векторов = " + v1.ToString());

                Console.WriteLine("Вектор v1:" + v1.ToString());
                Console.WriteLine("Вектор v2:" + v2.ToString());

                v1.Deduct(v2);
                Console.WriteLine("Разность векторов = " + v1.ToString());

                Vector multipliedScalar = v1.MultiplyScalar(5);
                Console.WriteLine("Произведение вектора v1 на число 5 = " + multipliedScalar.ToString());

                v1.Reverse();
                Console.WriteLine("Разворот вектора v1 = " + v1.ToString());

                double length = v1.GetLength();
                Console.WriteLine("Длинна вектора v1 = " + length);

                double component = v1.GetComponent(5);
                Console.WriteLine("Компонент вектора v1 по индексу 5 = " + component);

                Console.WriteLine("Заменим компонент вектора v1 по индексу 4 на число 99");
                v1.SetComponent(4, 99);
                Console.WriteLine(v1.ToString());

                Console.WriteLine("Проверим на эквивалентность v1 и v2");
                bool equals = v1.Equals(v2);
                Console.WriteLine("Получим: " + equals);

                Console.WriteLine("Получим hashCod векторов v1 и v2");
                Console.WriteLine("hashCod вектора v1  = " + v1.GetHashCode());
                Console.WriteLine("hashCod вектора v2  = " + v2.GetHashCode());

                Vector summa2 = Vector.GetSum(v1, v2);
                Console.WriteLine("Сумма векторов = " + summa2.ToString());

                Vector difference2 = Vector.GetDifference(v1, v2);
                Console.WriteLine("Разность векторов = " + difference2.ToString());

                double scalarMultiplication = Vector.GetScalarMultiplication(v1, v2);
                Console.WriteLine("Скалярное произведение векторов = " + scalarMultiplication);

                Vector v3 = new Vector(v2);
                Console.WriteLine("Вектор v3, копия вектора v2 = " + v3.ToString());
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
