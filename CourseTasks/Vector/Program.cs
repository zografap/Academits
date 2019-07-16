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
            double[] array1 = { 1, 1, 1, 2, 3 };

            double[] array2 = { 1, 1, 1 };

            Vector v1 = new Vector(array1);
            Vector v2 = new Vector(array2);

            Vector summa = v1.GetSumVector(v2);
            Console.WriteLine(summa.ToString());

            Vector difference = v1.GetDifferenceVector(v2);
            Console.WriteLine(difference.ToString());

            Vector multipliedScalar = v1.GetMultipliedScalar(5);
            Console.WriteLine(multipliedScalar.ToString());

            Vector revers = v1.GetVectorReversal();
            Console.WriteLine(revers.ToString());

            double length = v1.GetLength();
            Console.WriteLine("Длинна вектора = " + length);

            Console.ReadKey();
        }
    }
}
