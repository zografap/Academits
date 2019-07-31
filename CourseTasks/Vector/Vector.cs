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
            Array.Copy(array, Components, array.Length);
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            if (Components.Length == 0)
            {
                return "{ }";
            }

            foreach (int e in Components)
            {
                sb.Append(e);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }

        public Vector GetSumVector(Vector vector)
        {
            double[] array1 = new double[Components.Length];

            if (Components.Length < vector.Components.Length)
            {
                array1 = new double[vector.Components.Length];
                Array.Copy(Components, array1, Components.Length);
            }
            else if (Components.Length >= vector.Components.Length)
            {
                array1 = new double[Components.Length];
                Array.Copy(vector.Components, array1, vector.Components.Length);
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (Components.Length < vector.Components.Length)
                {
                    array1[i] = array1[i] + vector.Components[i];
                }
                else
                {
                    array1[i] = array1[i] + Components[i];
                }

            }
            Components = array1;

            return this;
        }

        public Vector GetDifferenceVector(Vector vector)
        {
            double[] array1 = new double[Components.Length];

            if (Components.Length < vector.Components.Length)
            {
                array1 = new double[vector.Components.Length];
                Array.Copy(Components, array1, Components.Length);
            }
            else if (Components.Length >= vector.Components.Length)
            {
                array1 = new double[Components.Length];
                Array.Copy(vector.Components, array1, vector.Components.Length);
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (Components.Length < vector.Components.Length)
                {
                    array1[i] = array1[i] - vector.Components[i];
                }
                else
                {
                    array1[i] = Components[i] - array1[i];
                }

            }
            Components = array1;

            return this;
        }

        public Vector MultiplyScalar(double scalar)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] *= scalar;
            }

            return this;
        }

        public Vector GetReversal()
        {
            return MultiplyScalar(-1);
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

        public double GetComponents(int index)
        {
            if (index < 0 || index >= Components.Length)
            {
                throw new IndexOutOfRangeException("index должно быть от 0 до " + Components.Length);
            }

            return Components[index];
        }

        public void SetComponents(int index, double component)
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

            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
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
            return new Vector(vector1.GetSumVector(vector2));
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.GetDifferenceVector(vector2));
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double sum = 0;

            if (vector1.Components.Length < vector2.Components.Length)
            {
                for (int i = 0; i < vector1.Components.Length; i++)
                {
                    sum += vector1.Components[i] * vector2.Components[i];
                }
            }
            else
            {
                for (int i = 0; i < vector2.Components.Length; i++)
                {
                    sum += vector1.Components[i] * vector2.Components[i];
                }
            }

            return sum;
        }
    }
}

