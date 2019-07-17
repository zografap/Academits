using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array1 = { 1, 1, 1, 5, 10, 15 };
            double[] array2 = { 1, 1, 1 };

            Vector v1 = new Vector(array1);
            Vector v2 = new Vector(array2);

            Console.WriteLine("Вектор v1:" + v1.ToString());
            Console.WriteLine("Вектор v2:" + v2.ToString());


            Vector summa = v1.GetSumVector(v2);
            Console.WriteLine("Сумма векторов = " + summa.ToString());

            Vector difference = v1.GetDifferenceVector(v2);
            Console.WriteLine("Разность векторов = " + difference.ToString());

            Vector multipliedScalar = v1.GetMultipliedScalar(5);
            Console.WriteLine("Произведение вектора v1 на число 5 = " + multipliedScalar.ToString());

            Vector revers = v1.GetVectorReversal();
            Console.WriteLine("Разворот вектора v1 = " + revers.ToString());

            double length = v1.GetLength();
            Console.WriteLine("Длинна вектора v1 = " + length);

            double component = v1.GetComponentsIndex(4);
            Console.WriteLine("Компонент вектора v1 по индексу 4 = " + component);

            Console.WriteLine("Заменим компонент вектора v1 по индексу 4 на число 99");
            Vector сomponent = v1.SetComponentsIndex(4, 99);
            Console.WriteLine(сomponent.ToString());

            Console.WriteLine("Проверим на эквивалентность v1 и v2");
            bool equals = v1.Equals(v2);
            Console.WriteLine("Получим: " + equals);

            Console.WriteLine("Получим hashCod векторов v1 и v2");
            Console.WriteLine("hashCod вектора v1  = " + v1.GetHashCode());
            Console.WriteLine("hashCod вектора v2  = " + v2.GetHashCode());

            Vector summa2 = Vector.GetSumTwo(v1, v2);
            Console.WriteLine("Сумма векторов = " + summa2.ToString());

            Vector difference2 = Vector.GetDifferenceTwo(v1, v2);
            Console.WriteLine("Разность векторов = " + difference2.ToString());

            Vector scalarMultiplication = Vector.GetScalarMultiplication(v1, v2);
            Console.WriteLine("Скалярное произведение векторов = " + scalarMultiplication.ToString());

            Console.ReadKey();
        }
    }
}
