using System;
using Vec = Vector.Vector;
namespace Matrix
{
    class Matrix
    {
        public int N { get; set; }
        public int M { get; set; }
        private Vec[] VectorArray { get; set; }
        private double[] MatrixArray { get; set; }

        public Matrix(int m, int n)
        {
            M = m;
            N = n;

            if (N <= 0 || M <= 0)
            {
                throw new ArgumentException("n и m должны быть > 0", nameof(N));
            }

            MatrixArray = new double[m];
            VectorArray = new Vec[m];
            Vec vector = new Vec(N);

            //for (int i = 0; i < N - 1; i++)
            //{
            //    vector.Components[i] = 0;
            //}
            for (int i = 0; i < M - 1; i++)
            {
                VectorArray[i] = vector;
            }
        }

        public Matrix(Matrix matrix)
        {
            VectorArray = new Vec[matrix.M];
            Vec vector = new Vec(matrix.N);

            Matrix matrixKopy = new Matrix(matrix.N, matrix.M);
            for (int i = 0; i < matrix.M; ++i)
            {
                matrixKopy.VectorArray[i] = new Vec(matrix.VectorArray[i]);
                //for (int j = 0; j < matrix.N - 1; j++)
                //{
                //    vector.Components[j] = matrix.VectorArray[j].Components[i];

                //}
            }
        }

        public override string ToString()
        {
            string stringOut = "{ ";


            for (int i = 0; i < M - 1; i++)
            {
                stringOut = stringOut + MatrixArray[i].ToString() + ", ";
            }

            stringOut = stringOut + "}";

            return stringOut;
        }
    }
}
