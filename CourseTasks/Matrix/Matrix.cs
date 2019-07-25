using System;
using System.Text;
using Vec = Vector.Vector;
namespace Matrix
{
    class Matrix
    {
        private Vec[] VectorArray { get; set; }

        public Matrix(int m, int n)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("n и m должны быть > 0", nameof(n));
            }

            VectorArray = new Vec[m];
            Vec VectorLine = new Vec(n);

            for (int i = 0; i < m; i++)
            {
                VectorArray[i] = VectorLine;
            }
        }

        public Matrix(Matrix matrix)
        {
            VectorArray = new Vec[matrix.VectorArray.Length];
            Array.Copy(matrix.VectorArray, VectorArray, matrix.VectorArray.Length);
        }

        public Matrix(double[][] data)
        {
            VectorArray = new Vec[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                VectorArray[i] = new Vec(data[i]);
            }
        }

        public Matrix(Vec[] vectors)
        {
            VectorArray = new Vec[vectors.Length];
            Array.Copy(vectors, VectorArray, vectors.Length);
        }

        public int[] GetDimensions()
        {
            return new int[] { VectorArray.Length, VectorArray[0].GetSize() };
        }

        public Vec GetRowVector(int index)
        {
            if (index < 0 || index > VectorArray.Length)

            {
                throw new ArgumentException("index должен быть от 0 до " + VectorArray.Length, nameof(index));
            }

            return VectorArray[index];
        }

        public void SetRowVector(int index, Vec vector)
        {
            if (vector.GetSize() != VectorArray.Length)

            {
                throw new ArgumentException("размер вектора должен быть " + VectorArray.Length, nameof(vector));
            }

            VectorArray[index] = new Vec(vector);
        }


        public Vec GetColumnVector(int index)
        {
            if (index < 0 || index > VectorArray[0].GetSize())

            {
                throw new ArgumentException("index должен быть от 0 до " + VectorArray[0].GetSize(), nameof(index));
            }
            Vec columnVector = new Vec(VectorArray.Length);

            for (int i = 0; i < VectorArray.Length; i++)
            {
                columnVector.SetComponents(i, VectorArray[i].GetComponents(index));
            }

            return columnVector;
        }

        public Matrix GetTranspose()
        {
            Matrix result = new Matrix(VectorArray[0].GetSize(), VectorArray.Length);

            for (int i = 0; i < VectorArray[0].GetSize(); i++)
            {
                result.VectorArray[i] = GetColumnVector(i);
            }

            return result;
        }

        public Matrix GetMultipliedScalar(double scalar)
        {
            for (int i = 0; i < VectorArray.Length; i++)
            {
                VectorArray[i] = VectorArray[i].MultipliedScalar(scalar);
            }

            return this;
        }

        public static Matrix GetMinor(Matrix matrix, int row, int column)
        {
            int minorLength = matrix.VectorArray.Length - 1;
            Matrix minor = new Matrix(minorLength, minorLength);
            int dI = 0;
            int dJ;
            for (int i = 0; i <= minorLength; i++)
            {
                dJ = 0;
                for (int j = 0; j <= minorLength; j++)
                {
                    if (i == row)
                    {
                        dI = 1;
                    }
                    else
                    {
                        if (j == column)
                        {
                            dJ = 1;
                        }
                        else
                        {
                            matrix.VectorArray[i - dI].SetComponents(j - dJ, matrix.VectorArray[i].GetComponents(j));
                        }
                    }
                }
            }
            return minor;
        }

        public static double GetDeterminant(Matrix matrix)
        {
            if (matrix.VectorArray.Length != matrix.VectorArray[0].GetSize())

            {
                throw new ArgumentException("Матрица должна быть квадратной!", nameof(matrix.VectorArray.Length));
            }

            if (matrix.VectorArray.Length == 1)
            {
                return matrix.VectorArray[0].GetComponents(0);
            }
            else if (matrix.VectorArray.Length == 2)
            {
                return matrix.VectorArray[0].GetComponents(0) * matrix.VectorArray[1].GetComponents(1)
                    - matrix.VectorArray[1].GetComponents(0) * matrix.VectorArray[0].GetComponents(1);
            }

            double determinant = 0.0;

            for (int i = 0; i < matrix.VectorArray.Length; i++)
            {
                int coefficient = (i % 2 == 1) ? -1 : 1;
                determinant += coefficient * matrix.VectorArray[0].GetComponents(i) * GetDeterminant(GetMinor(matrix, 0, i));
            }

            return determinant;
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

        public Vec GetMultiplicationByVector(Vec vector)
        {
            if (VectorArray.Length != vector.GetLength())

            {
                throw new ArgumentException("Количество строк матрицы должно быть равно длинне вектора ", nameof(VectorArray.Length));
            }
        }
    }
}
