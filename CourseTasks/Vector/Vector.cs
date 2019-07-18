using System;

namespace Vector
{
    public class Vector
    {
        public int N { get; set; }
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

        public double GetComponentsIndex(int n)
        {
            return Array[n];
        }

        public Vector SetComponentsIndex(int n, double component)
        {
            Array[n] = component;

            return new Vector(Array);
        }

        public bool ArrayCompare(double[] a, double[] b)
        {
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        return false;
                    };
                }

                return true;
            }

            return false;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }

            Vector p = (Vector)o;

            return N == p.N && ArrayCompare(Array, p.Array);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + N.GetHashCode();

            for (int i = 0; i < Array.Length; i++)
                hash = prime * hash + Array[i].GetHashCode();

            return hash;
        }

        public static Vector GetSumTwo(Vector vector1, Vector vector2)
        {
            if (vector1.N == vector2.N)
            {
                int N = vector1.N;
                //Array arrayResult = new double[N]; ;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    vectorResult.Array[i] = vector1.Array[i] + vector2.Array[i];
                }
                return vectorResult;
            }
            else if (vector1.N > vector2.N)
            {
                int N = vector1.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i > vector2.Array.Length - 1)
                    {
                        vectorResult.Array[i] = vector1.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = vector2.Array[i] + vector1.Array[i];
                    }
                }
                return vectorResult;
            }
            else
            {
                int N = vector2.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i < N)
                    {
                        vectorResult.Array[i] = vector2.Array[i] + vector1.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = vector2.Array[i];
                    }
                }
                return vectorResult;
            }
        }

        public static Vector GetDifferenceTwo(Vector vector1, Vector vector2)
        {
            if (vector1.N == vector2.N)
            {
                int N = vector1.N;
                //Array arrayResult = new double[N]; ;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    vectorResult.Array[i] = vector1.Array[i] - vector2.Array[i];
                }
                return vectorResult;
            }
            else if (vector1.N > vector2.N)
            {
                int N = vector1.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i > vector2.Array.Length - 1)
                    {
                        vectorResult.Array[i] = 0 - vector1.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = vector1.Array[i] - vector2.Array[i];
                    }
                }
                return vectorResult;
            }
            else
            {
                int N = vector2.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i < N)
                    {
                        vectorResult.Array[i] = vector1.Array[i] + vector2.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = 0 - vector2.Array[i];
                    }
                }
                return vectorResult;
            }
        }

        public static Vector GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            if (vector1.N == vector2.N)
            {
                int N = vector1.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    vectorResult.Array[i] = vector1.Array[i] * vector2.Array[i];
                }
                return vectorResult;
            }
            else if (vector1.N > vector2.N)
            {
                int N = vector1.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i > vector2.Array.Length - 1)
                    {
                        vectorResult.Array[i] = 0 * vector1.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = vector1.Array[i] * vector2.Array[i];
                    }
                }
                return vectorResult;
            }
            else
            {
                int N = vector2.N;
                Vector vectorResult = new Vector(new double[N]);

                for (int i = 0; i < vectorResult.Array.Length; i++)
                {
                    if (i < N)
                    {
                        vectorResult.Array[i] = vector1.Array[i] + vector2.Array[i];
                    }
                    else
                    {
                        vectorResult.Array[i] = 0 * vector2.Array[i];
                    }
                }
                return vectorResult;
            }
        }
    }
}

