using System;
using System.Text;
using Vec = Vector.Vector;
namespace Matrix
{
    class Matrix
    {
        private Vec[] Vectors { get; set; }

        public Matrix(int numberOfLines, int numberOfColumns)
        {
            if (numberOfColumns <= 0 || numberOfLines <= 0)
            {
                throw new ArgumentException("количество строк и столбцов должно быть > 0", nameof(numberOfColumns));
            }

            Vectors = new Vec[numberOfLines];

            for (int i = 0; i < numberOfLines; i++)
            {
                Vectors[i] = new Vec(numberOfColumns);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix.GetNumberOfRows() == 0 || matrix.GetNumberOfСolumns() == 0)
            {
                throw new ArgumentException("размер матрицы должен быть > 0");
            }
            Vectors = new Vec[matrix.GetNumberOfRows()];

            for (int i = 0; i < matrix.GetNumberOfRows(); i++)
            {
                Vectors[i] = new Vec(matrix.Vectors[i]);
            }
        }

        public Matrix(double[][] data)
        {
            if (data.GetLength(0) == 0)
            {
                throw new ArgumentException("размер массива должен быть > 0");
            }

            int maxLength = 0;

            for (int i = 0; i < data.GetLength(0); ++i)
            {
                if (data[i].Length > maxLength)
                {
                    maxLength = data[i].Length;
                }
            }

            double[,] array = new double[data.GetLength(0), maxLength];

            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    if (j < data[i].Length)
                    {
                        array[i, j] = data[i][j];
                    }
                }
            }

            Vectors = new Vec[data.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Vectors[i] = new Vec(array.GetLength(1));

                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    Vectors[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vec[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException("размер массива должен быть > 0");
            }

            int maxLength = 0;

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                if (vectors[i].GetSize() > maxLength)
                {
                    maxLength = vectors[i].GetSize();
                }
            }

            Vectors = new Vec[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                Vectors[i] = new Vec(maxLength);

                for (int j = 0; j < vectors[i].GetSize(); ++j)
                {
                    Vectors[i].SetComponent(j, vectors[i].GetComponent(j));
                }
            }
        }

        public int GetNumberOfRows()
        {
            return Vectors.Length;
        }

        public int GetNumberOfСolumns()
        {
            return Vectors[0].GetSize();
        }

        public Vec GetRowVector(int index)
        {
            if (index < 0 || index > Vectors.Length)
            {
                throw new IndexOutOfRangeException("index должен быть от 0 до " + Vectors.Length);
            }

            return Vectors[index];
        }

        public void SetRowVector(int index, Vec vector)
        {
            if (vector.GetSize() != Vectors.Length)

            {
                throw new ArgumentOutOfRangeException("размер вектора должен быть " + Vectors.Length, nameof(vector));
            }

            Vectors[index] = new Vec(vector);
        }

        public Vec GetColumnVector(int index)
        {
            if (index < 0 || index > Vectors[0].GetSize())

            {
                throw new IndexOutOfRangeException("index должен быть от 0 до " + Vectors[0].GetSize());
            }
            Vec columnVector = new Vec(Vectors.Length);

            for (int i = 0; i < Vectors.Length; i++)
            {
                columnVector.SetComponent(i, Vectors[i].GetComponent(index));
            }

            return columnVector;
        }

        public Matrix GetTranspose()
        {
            Matrix result = new Matrix(Vectors[0].GetSize(), Vectors.Length);

            for (int i = 0; i < Vectors[0].GetSize(); i++)
            {
                result.Vectors[i] = GetColumnVector(i);
            }

            return result;
        }

        public Matrix GetMultipliedScalar(double scalar)
        {
            for (int i = 0; i < Vectors.Length; i++)
            {
                Vectors[i] = Vectors[i].MultiplyScalar(scalar);
            }

            return this;
        }

        public static Matrix GetMinor(Matrix matrix, int row, int column)
        {
            int minorLength = matrix.Vectors.Length - 1;
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
                            matrix.Vectors[i - dI].SetComponent(j - dJ, matrix.Vectors[i].GetComponent(j));
                        }
                    }
                }
            }
            return minor;
        }

        public static double GetDeterminant(Matrix matrix)
        {
            if (matrix.Vectors.Length != matrix.Vectors[0].GetSize())

            {
                throw new ArgumentException("Матрица должна быть квадратной!", nameof(matrix.Vectors.Length));
            }

            if (matrix.Vectors.Length == 1)
            {
                return matrix.Vectors[0].GetComponent(0);
            }
            else if (matrix.Vectors.Length == 2)
            {
                return matrix.Vectors[0].GetComponent(0) * matrix.Vectors[1].GetComponent(1)
                    - matrix.Vectors[1].GetComponent(0) * matrix.Vectors[0].GetComponent(1);
            }

            double determinant = 0.0;

            for (int i = 0; i < matrix.Vectors.Length; i++)
            {
                int coefficient = (i % 2 == 1) ? -1 : 1;
                determinant += coefficient * matrix.Vectors[0].GetComponent(i) * GetDeterminant(GetMinor(matrix, 0, i));
            }

            return determinant;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            foreach (Vec e in Vectors)
            {
                sb.Append(e + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }

        public Vec GetMultiplicationByVector(Vec vector)
        {
            if (Vectors.Length != vector.GetSize())
            {
                throw new ArgumentException("Количество строк матрицы должно быть равно длинне вектора ", nameof(Vectors.Length));
            }

            Vec vectorResult = new Vec(vector.GetSize());

            for (int i = 0; i < Vectors.Length; i++)
            {
                double sum = 0;

                for (int j = 0; j < Vectors[i].GetSize(); j++)
                {
                    sum += Vectors[i].GetComponent(j) * vector.GetComponent(i);
                }

                vectorResult.SetComponent(i, sum);
            }

            return vectorResult;
        }

        public Matrix AddMatrix(Matrix matrix)
        {
            if (GetNumberOfRows() == matrix.GetNumberOfRows() && GetNumberOfСolumns() == matrix.GetNumberOfСolumns())
            {
                Matrix matrixResult = new Matrix(matrix);

                for (int i = 0; i < matrix.Vectors.Length; i++)
                {
                    Vectors[i].Add(matrix.Vectors[i]);
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
            if (GetNumberOfRows() == matrix.GetNumberOfRows() && GetNumberOfСolumns() == matrix.GetNumberOfСolumns())
            {
                Matrix matrixResult = new Matrix(matrix);

                for (int i = 0; i < matrix.Vectors.Length; i++)
                {
                    Vectors[i].Deduct(matrix.Vectors[i]);
                    matrixResult.Vectors[i] = Vectors[i];
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
            if (matrix1.GetNumberOfСolumns() == matrix2.GetNumberOfRows())
            {
                Matrix matrixResult = new Matrix(matrix1.GetNumberOfRows(), matrix2.GetNumberOfСolumns());
                Vec[] vectors = new Vec[matrixResult.GetNumberOfRows()];

                for (int i = 0; i < vectors.Length; i++)
                {
                    vectors[i] = new Vec(matrix2.GetNumberOfСolumns());
                }

                for (int i = 0; i < matrixResult.Vectors.Length; i++)
                {
                    for (int j = 0; j < matrixResult.Vectors[i].GetSize(); j++)
                    {
                        Vec columnVector = matrix2.GetColumnVector(j);
                        double x = Vec.GetScalarMultiplication(matrix1.Vectors[i], columnVector);
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
