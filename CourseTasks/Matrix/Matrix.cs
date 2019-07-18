using System;
using Vec = Vector.Vector;
namespace Matrix
{
       class Matrix
    {
        private int N { get; set; }
        private int M { get; set; }
        public Vec[] MatrixArray { get; set; }

        public Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("n и m должны быть > 0", nameof(n));
            }
            Vec vector = new Vec(n);
            vector.N = n;

            MatrixArray = new Vec[m];

            for (int i = 0; i < n - 1; i++)
            {
                vector.Array[i] = 0;
            }

            for (int i = 0; i < m - 1; i++)
            {
                MatrixArray[i] = vector;
            }
        }

        public override string ToString()
        {
            string stringOut = "{ ";

            for (int i = 0; i < MatrixArray.Length - 1; i++)
            {
                stringOut = stringOut + MatrixArray[i].ToString() + ", ";
            }

            stringOut = stringOut + "}";

            return stringOut;
        }
    }
}
