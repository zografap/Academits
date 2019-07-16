using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private int N { get; set; }
        public double[] Array { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }
            N = n;
            Array = new double[n];
        }

        public Vector(Vector vector)
        {
            N = vector.N;
            Array = new double[vector.N];
        }

        public Vector(double[] array)
        {
            N = array.Length;
            Array = new double[N];

            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            N = n;
            Array = new double[n];

            for (int i = 0; i < n - 1; i++)
            {
                if (i > array.Length - 1)
                {
                    Array[i] = 0;
                }
                else
                {
                    Array[i] = array[i];
                }
            }
        }

        public int GetSize()
        {
            return N;
        }

        public override string ToString()
        {
            string stringOut = "{ ";

            if (Array == null)
            {
                stringOut = "Массив пуст";
            }
            else
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    stringOut = stringOut + Array[i] + ", ";
                }
            }

            stringOut = stringOut + "}";

            return stringOut;
        }

        public Vector GetSumVector(Vector vector)
        {
            if (N == vector.N)
            {
                Vector vectorResult = new Vector(Array);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    vectorResult.Array[i] = Array[i] + vector.Array[i];
                }
                return vectorResult;
            }
            else if (N > vector.N)
            {
                Vector vectorResult = new Vector(Array);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i > vector.Array.Length - 1)
                    {
                        vectorResult.Array[i] = Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = Array[i] + vector.Array[i];
                    }
                }
                return vectorResult;
            }
            else
            {
                Vector vectorResult = new Vector(vector.Array);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i < N)
                    {
                        vectorResult.Array[i] = Array[i] + vector.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = vector.Array[i];
                    }
                }
                return vectorResult;
            }
        }

        public Vector GetDifferenceVector(Vector vector)
        {
            if (N == vector.N)
            {
                Vector vectorResult1 = new Vector(new double[N]);

                for (int i = 0; i < vectorResult1.Array.Length; i++)
                {
                    vectorResult1.Array[i] = Array[i] - vector.Array[i];
                }
                return vectorResult1;
            }
            else if (N > vector.N)
            {
                Vector vectorResult1 = new Vector(new double[N]);

                for (int i = 0; i < vectorResult1.Array.Length; i++)
                {
                    if (i > vector.Array.Length - 1)
                    {
                        vectorResult1.Array[i] = Array[i];
                    }
                    else
                    {
                        vectorResult1.Array[i] = Array[i] - vector.Array[i];
                    }
                }
                return vectorResult1;
            }
            else
            {
                Vector vectorResult = new Vector(new double[vector.N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i < N)
                    {
                        vectorResult.Array[i] = Array[i] - vector.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = 0 - vector.Array[i];
                    }
                }

                return vectorResult;
            }
        }

        public Vector GetMultipliedScalar(double scalar)
        {
            Vector vectorResult = new Vector(new double[N]);

            for (int i = 0; i < N; i++)
            {
                vectorResult.Array[i] = Array[i] * scalar;
            }

            return vectorResult;
        }

        public Vector GetVectorReversal()
        {
            Vector vectorResult = new Vector(new double[N]);

            for (int i = 0; i < N; i++)
            {
                vectorResult.Array[i] = Array[i] * -1;
            }

            return vectorResult;
        }

        public double GetLength()
        { 
             double summa = 0;

            for (int i = 0; i < N; i++)
            {
                summa = summa + Math.Pow(Array[i], 2);
            }

            return Math.Sqrt(summa);
        }
    }
}

