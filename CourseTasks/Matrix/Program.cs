using System;


namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matrix matrix1 = new Matrix(4, 4);
                Console.WriteLine(matrix1.ToString());

                
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
