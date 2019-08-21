using System;
using System.Text;
using Vec = Vector.Vector;
namespace Matrix
{
    class Matrix
    {
        private Vec[] Rows { get; set; }

        public Matrix(int rowCount, int сolumnsCount)
        {
            if (сolumnsCount <= 0 || rowCount <= 0)
            {
                throw new ArgumentException("количество строк и столбцов должно быть > 0", nameof(сolumnsCount));
            }

            Rows = new Vec[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                Rows[i] = new Vec(сolumnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix.GetRowsCount() == 0)
            {
                throw new ArgumentException("размер матрицы должен быть > 0");
            }
            Rows = new Vec[matrix.GetRowsCount()];

            for (int i = 0; i < matrix.GetRowsCount(); i++)
            {
                Rows[i] = new Vec(matrix.Rows[i]);
            }
        }

        public Matrix(double[,] data)
        {
            if (data.GetLength(0) == 0)
            {
                throw new ArgumentException("размер массива должен быть > 0");
            }

            Rows = new Vec[data.GetLength(0)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                Rows[i] = new Vec(data.GetLength(1));

                for (int j = 0; j < data.GetLength(1); ++j)
                {
                    Rows[i].SetComponent(j, data[i, j]);
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

            foreach (Vec e in vectors)
            {
                if (e.GetSize() > maxLength)
                {
                    maxLength = e.GetSize();
                }
            }

            Rows = new Vec[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                Rows[i] = new Vec(maxLength);

                for (int j = 0; j < vectors[i].GetSize(); ++j)
                {
                    Rows[i].SetComponent(j, vectors[i].GetComponent(j));
                }
            }
        }

        public int GetRowsCount()
        {
            return Rows.Length;
        }

        public int GetСolumnsCount()
        {
            return Rows[0].GetSize();
        }

        public Vec GetRow(int index)
        {
            if (index < 0 || index > Rows.Length)
            {
                throw new IndexOutOfRangeException("index должен быть от 0 до " + Rows.Length);
            }

            return new Vec(Rows[index]);
        }

        public void SetRow(int index, Vec vector)
        {
            if (vector.GetSize() != GetСolumnsCount())
            {
                throw new ArgumentOutOfRangeException("размер вектора должен быть " + Rows[index].GetSize(), nameof(vector));
            }

            if (index < 0 || index > Rows.Length)
            {
                throw new IndexOutOfRangeException("index должен быть от 0 до " + Rows.Length);
            }

            Rows[index] = new Vec(vector);
        }

        public Vec GetColumn(int index)
        {
            if (index < 0 || index > Rows[0].GetSize())
            {
                throw new IndexOutOfRangeException("index должен быть от 0 до " + Rows[0].GetSize());
            }

            Vec columnVector = new Vec(Rows.Length);

            for (int i = 0; i < Rows.Length; i++)
            {
                columnVector.SetComponent(i, Rows[i].GetComponent(index));
            }

            return columnVector;
        }

        public Matrix Transpose()
        {
            Vec[] vectors = new Vec[GetСolumnsCount()];

            for (int i = 0; i < Rows[0].GetSize(); i++)
            {
                vectors[i] = GetColumn(i);
            }

            Rows = vectors;

            return this;
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            foreach (Vec e in Rows)
            {
                e.MultiplyScalar(scalar);
            }

            return this;
        }

        private static Matrix GetMinor(Matrix matrix, int row, int column)
        {
            int minorLength = matrix.Rows.Length - 1;
            Matrix minor = new Matrix(minorLength, minorLength);
            int dI = 0;

            for (int i = 0; i <= minorLength; i++)
            {
                int dJ = 0;

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
                            matrix.Rows[i - dI].SetComponent(j - dJ, matrix.Rows[i].GetComponent(j));
                        }
                    }
                }
            }
            return minor;
        }

        public double GetDeterminant()
        {
            if (Rows.Length != Rows[0].GetSize())
            {
                throw new ArgumentException("Матрица должна быть квадратной!");
            }

            if (Rows.Length == 1)
            {
                return Rows[0].GetComponent(0);
            }

            if (Rows.Length == 2)
            {
                return Rows[0].GetComponent(0) * Rows[1].GetComponent(1)
                    - Rows[1].GetComponent(0) * Rows[0].GetComponent(1);
            }

            double determinant = 0.0;

            for (int i = 0; i < Rows.Length; i++)
            {
                int coefficient = (i % 2 == 1) ? -1 : 1;
                determinant += coefficient * Rows[0].GetComponent(i) * GetMinor(this, 0, i).GetDeterminant();
            }

            return determinant;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            foreach (Vec e in Rows)
            {
                sb.Append(e);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }

        public Vec MultiplyByVector(Vec vector)
        {
            if (GetСolumnsCount() != vector.GetSize())
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть равно длинне вектора ");
            }

            Vec vectorResult = new Vec(vector.GetSize());

            for (int i = 0; i < vector.GetSize(); i++)
            {
                double sum = 0;

                for (int j = 0; j < Rows.Length; j++)
                {
                    sum += Rows[i].GetComponent(j) * vector.GetComponent(j);
                }

                vectorResult.SetComponent(i, sum);
            }

            return vectorResult;
        }

        public Matrix AddMatrix(Matrix matrix)
        {
            if (GetRowsCount() != matrix.GetRowsCount() || GetСolumnsCount() != matrix.GetСolumnsCount())
            {
                throw new Exception("Матрицы должны быть одинаковой размерности ");
            }

            for (int i = 0; i < matrix.Rows.Length; i++)
            {
                Rows[i].Add(matrix.Rows[i]);
            }

            return this;
        }

        public Matrix DeductMatrix(Matrix matrix)
        {
            if (GetRowsCount() != matrix.GetRowsCount() || GetСolumnsCount() != matrix.GetСolumnsCount())
            {
                throw new Exception("Матрицы должны быть одинаковой размерности ");
            }

            for (int i = 0; i < matrix.Rows.Length; i++)
            {
                Rows[i].Deduct(matrix.Rows[i]);
            }

            return this;
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetRowsCount() != matrix2.GetRowsCount() || matrix1.GetСolumnsCount() != matrix2.GetСolumnsCount())
            {
                throw new Exception("Матрицы должны быть одинаковой размерности ");
            }

            Matrix matrixSum = new Matrix(matrix1);

            return matrixSum.AddMatrix(matrix2);

        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetRowsCount() != matrix2.GetRowsCount() || matrix1.GetСolumnsCount() != matrix2.GetСolumnsCount())
            {
                throw new Exception("Матрицы должны быть одинаковой размерности ");
            }

            Matrix matrixDifference = new Matrix(matrix1);

            return matrixDifference.DeductMatrix(matrix2);
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetСolumnsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Число столбцов в первой матрице должно быть равно числу строк во второй");
            }

            Vec[] vectors = new Vec[matrix1.GetRowsCount()];

            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] = new Vec(matrix2.GetСolumnsCount());
            }

            for (int i = 0; i < matrix1.GetRowsCount(); i++)
            {
                for (int j = 0; j < matrix2.GetСolumnsCount(); j++)
                {
                    Vec columnVector = matrix2.GetColumn(j);
                    double x = Vec.GetScalarMultiplication(matrix1.Rows[i], columnVector);
                    vectors[i].SetComponent(j, x);
                }
            }

            return new Matrix(vectors);
        }
    }
}
