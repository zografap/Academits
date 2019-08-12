using System;
using System.Text;

namespace Vector
{
    public class Vector
    {
        private double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }

            Components = new double[n];
        }

        public Vector(Vector vector) : this(vector.Components)
        {
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("длинна массива должна быть > 0", nameof(array.Length));
            }

            Components = new double[array.Length];
            Array.Copy(array, Components, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }

            Components = new double[n];
            Array.Copy(array, 0, Components, 0, Math.Min(n, array.Length));
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            foreach (double e in Components)
            {
                sb.Append(e);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }

        public void Add(Vector vector)
        {
            if (Components.Length < vector.Components.Length)
            {
                double[] array = new double[vector.Components.Length];

                for (int i = 0; i < vector.Components.Length; i++)
                {
                    if (i < Components.Length)
                    {
                        array[i] = Components[i] + vector.Components[i];
                    }
                    else
                    {
                        array[i] = vector.Components[i];
                    }
                }
                Components = array;
            }
            else
            {
                for (int i = 0; i < vector.Components.Length; i++)
                {
                    Components[i] += vector.Components[i];
                }
            }
        }

        public void Deduct(Vector vector)
        {
            if (Components.Length < vector.Components.Length)
            {
                double[] array = new double[vector.Components.Length];

                for (int i = 0; i < vector.Components.Length; i++)
                {
                    if (i < Components.Length)
                    {
                        array[i] = Components[i] - vector.Components[i];
                    }
                    else
                    {
                        array[i] = -1 * vector.Components[i];
                    }
                }
                Components = array;
            }
            else
            {
                for (int i = 0; i < vector.Components.Length; i++)
                {
                    Components[i] -= vector.Components[i];
                }
            }
        }

        public Vector MultiplyScalar(double scalar)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] *= scalar;
            }

            return this;
        }

        public void Reverse()
        {
            MultiplyScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double e in Components)
            {
                sum += Math.Pow(e, 2);
            }

            return Math.Sqrt(sum);
        }

        public double GetComponent(int index)
        {
            if (index < 0 || index >= Components.Length)
            {
                throw new IndexOutOfRangeException("index должно быть от 0 до " + Components.Length);
            }

            return Components[index];
        }

        public void SetComponent(int index, double component)
        {
            if (index < 0 || index >= Components.Length)
            {
                throw new IndexOutOfRangeException("index должно быть от 0 до " + Components.Length);
            }

            Components[index] = component;
        }

        private static bool IsArrayEquals(double[] a, double[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }

            Vector p = (Vector)o;

            return IsArrayEquals(Components, p.Components);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double e in Components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector vectorSum = new Vector(vector1);
            vectorSum.Add(vector2);

            return vectorSum;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector vectorDifference = new Vector(vector1);
            vectorDifference.Deduct(vector2);

            return vectorDifference;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double sum = 0;
            int minimumLength = Math.Min(vector1.Components.Length, vector2.Components.Length);

            for (int i = 0; i < minimumLength; i++)
            {
                sum += vector1.Components[i] * vector2.Components[i];
            }

            return sum;
        }
    }
}

