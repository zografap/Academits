using System;
using System.Text;
using Vec = Vector.Vector;
namespace Matrix
{
    class Matrix
    {
        //public int N { get; set; }
        //private Vec VectorLine { get; set; }
        private Vec[] VectorArray { get; set; }
        //private double[] MatrixArray { get; set; }

        public Matrix(int m, int n)
        {
            //M = m;
            //N = n;

            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("n и m должны быть > 0", nameof(n));
            }

            VectorArray = new Vec[m];
            Vec VectorLine = new Vec(n);

            for (int i = 0; i < m - 1; i++)
            {
                VectorArray[i] = VectorLine;
            }
        }

        public Matrix(Matrix matrix)
        {
            VectorArray = new Vec[matrix.VectorArray.Length];
            //Vec VectorLine = new Vec(matrix.VectorLine.GetSize());

            Matrix matrixKopy = new Matrix(matrix.VectorArray.Length, matrix.VectorArray.Length);
            for (int i = 0; i < matrix.VectorArray.Length; ++i)
            {
                matrixKopy.VectorArray[i] = matrix.VectorArray[i];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            foreach (Vec e in VectorArray)
            {
                sb.Append(e + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
