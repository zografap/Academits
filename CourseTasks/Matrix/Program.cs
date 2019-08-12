using System;
using Vec = Vector.Vector;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matrix matrix1 = new Matrix(3, 5);
                Console.WriteLine("matrix1: " + matrix1.ToString());

                Matrix matrix2 = new Matrix(matrix1);
                Console.WriteLine("matrix2: " + matrix2.ToString());

                double[][] array1 = new double[3][];
                array1[0] = new double[3] { 1, 1, 1 };
                array1[1] = new double[3] { 2, 2, 2 };
                array1[2] = new double[3] { 3, 3, 3 };

                Matrix matrix3 = new Matrix(array1);
                Console.WriteLine("matrix3: " + matrix3.ToString());

                Vec[] vectors = new Vec[3];
                double[] array2 = { 1, 1, 1 };
                Vec v1 = new Vec(array2);
                vectors[0] = v1;
                vectors[1] = v1;
                vectors[2] = v1;
                Matrix matrix4 = new Matrix(vectors);
                Console.WriteLine("matrix4: " + matrix4.ToString());

                Console.WriteLine("Размеры матрицы matrix4 = " + matrix4.GetNumberOfRows() +
                    " на " + matrix4.GetNumberOfСolumns());

                Console.WriteLine("Размеры матрицы matrix1 = " + matrix1.GetNumberOfRows() +
                    " на " + matrix1.GetNumberOfСolumns());

                Console.WriteLine("Получим вектор строку matrix3 по индексу 1 : " + matrix3.GetRow(1).ToString());

                matrix3.SetRow(1, v1);
                Console.WriteLine("Установим в matrix3 строку с индексом 1 равную вектору v1: " + matrix3.ToString());

                Matrix matrix5 = new Matrix(array1);
                Console.WriteLine("Получим вектор столбец с индексом 1 из matrix5: " + matrix5.GetColumn(1).ToString());

                Console.WriteLine("Транспонируем matrix5 получим: " + matrix5.GetTranspose().ToString());

                Console.WriteLine("matrix5: " + matrix5.ToString());

                Console.WriteLine("Умножим matrix5 на 10 получим: " + matrix5.GetMultipliedScalar(10).ToString());
                Console.WriteLine("matrix3: " + matrix3.ToString());
                Console.WriteLine("Детерминант matrix3 = " + matrix3.GetDeterminant().ToString());

                double[] array5 = { 3, 3, 3 };
                Vec v5 = new Vec(array5);
                Console.WriteLine("matrix5: " + matrix5.ToString());
                Console.WriteLine("вектор5 v5: " + v5.ToString());
                Console.WriteLine("Умножим matrix5 на v5 получим:" + matrix5.MultiplyByVector(v5).ToString());

                Console.WriteLine("matrix5: " + matrix5.ToString());
                Console.WriteLine("matrix3: " + matrix3.ToString());
                Console.WriteLine("Сложим matrix5 и matrix3 получим:" + matrix5.AddMatrix(matrix3).ToString());
                Console.WriteLine("Отнимем от matrix5 matrix3 получим:" + matrix5.DeductMatrix(matrix3).ToString());
                Console.WriteLine();
                Console.WriteLine("matrix5: " + matrix5.ToString());
                Console.WriteLine("matrix3: " + matrix3.ToString());
                Console.WriteLine("Умножим matrix5 на matrix3 получим:" + Matrix.GetMultiplication(matrix5, matrix3).ToString());
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
