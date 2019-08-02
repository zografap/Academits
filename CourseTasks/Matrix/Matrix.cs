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
                columnVector.SetComponent(i, VectorArray[i].GetComponent(index));
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
                VectorArray[i] = VectorArray[i].MultiplyScalar(scalar);
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
                            matrix.VectorArray[i - dI].SetComponent(j - dJ, matrix.VectorArray[i].GetComponent(j));
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
                return matrix.VectorArray[0].GetComponent(0);
            }
            else if (matrix.VectorArray.Length == 2)
            {
                return matrix.VectorArray[0].GetComponent(0) * matrix.VectorArray[1].GetComponent(1)
                    - matrix.VectorArray[1].GetComponent(0) * matrix.VectorArray[0].GetComponent(1);
            }

            double determinant = 0.0;

            for (int i = 0; i < matrix.VectorArray.Length; i++)
            {
                int coefficient = (i % 2 == 1) ? -1 : 1;
                determinant += coefficient * matrix.VectorArray[0].GetComponent(i) * GetDeterminant(GetMinor(matrix, 0, i));
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
            if (VectorArray.Length != vector.GetSize())
            {
                throw new ArgumentException("Количество строк матрицы должно быть равно длинне вектора ", nameof(VectorArray.Length));
            }

            Vec vectorResult = new Vec(vector.GetSize());

            for (int i = 0; i < VectorArray.Length; i++)
            {
                double sum = 0;

                for (int j = 0; j < VectorArray[i].GetSize(); j++)
                {
                    sum += VectorArray[i].GetComponent(j) * vector.GetComponent(i);
                }

                vectorResult.SetComponent(i, sum);
            }

            return vectorResult;
        }

        public Matrix AddMatrix(Matrix matrix)
        {
            if (GetDimensions()[0] == matrix.GetDimensions()[0] && GetDimensions()[1] == matrix.GetDimensions()[1])
            {
                Matrix matrixResult = new Matrix(matrix);

                for (int i = 0; i < matrix.VectorArray.Length; i++)
                {
                    VectorArray[i].Add(matrix.VectorArray[i]);
                }

                return matrixResult;
            }

            else
            {
                throw new Exception("Матрицы должны быть одинаковой размерности ");
            }
        }

        public Matrix TakeAwayMatrix(Matrix matrix)
        {
            if (GetDimensions()[0] == matrix.GetDimensions()[0] && GetDimensions()[1] == matrix.GetDimensions()[1])
            {
                Matrix matrixResult = new Matrix(matrix);

                for (int i = 0; i < matrix.VectorArray.Length; i++)
                {
                    VectorArray[i].Deduct(matrix.VectorArray[i]);
                    matrixResult.VectorArray[i] = VectorArray[i];
                }

                return matrixResult;
            }

            else
            {
                throw new Exception("Матрицы должны быть одинаковой размерности ");
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            return new Matrix(matrix1.AddMatrix(matrix2));
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            return new Matrix(matrix1.TakeAwayMatrix(matrix2));
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetDimensions()[1] == matrix2.GetDimensions()[0])
            {
                Matrix matrixResult = new Matrix(matrix1.GetDimensions()[0], matrix2.GetDimensions()[1]);
                Vec[] vectors = new Vec[matrixResult.GetDimensions()[0]];

                for (int i = 0; i < vectors.Length; i++)
                {
                    vectors[i] = new Vec(matrix2.GetDimensions()[1]);
                }

                for (int i = 0; i < matrixResult.VectorArray.Length; i++)
                {
                    for (int j = 0; j < matrixResult.VectorArray[i].GetSize(); j++)
                    {
                        Vec columnVector = matrix2.GetColumnVector(j);
                        double x = Vec.GetScalarMultiplication(matrix1.VectorArray[i], columnVector);
                        vectors[i].SetComponent(j, x);
                    }
                }

                matrixResult = new Matrix(vectors);

                return matrixResult;
            }
            else
            {
                throw new Exception("Число столбцов в первой матрице должно быть равно числу строк во вторй");
            }
        }
    }
}
