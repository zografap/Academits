using System;


namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matrix matrix1 = new Matrix(5, 5);
                Console.WriteLine(matrix1.ToString());
                //Console.WriteLine(matrix1.M + " " + matrix1.N);

                Matrix matrix2 = new Matrix(matrix1);
                Console.WriteLine(matrix2.ToString());

                //double[] array1 = { 1, 1, 1, 5, 10, 15 };


            }
            catch
            {
                Console.WriteLine("n и m должны быть > 0");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
