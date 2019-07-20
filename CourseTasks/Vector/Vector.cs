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

        public Vector(Vector vector)
        {
            if (vector.Components.Length == 0)

            {
                throw new ArgumentException("длинна вектора должна быть > 0", nameof(vector.Components.Length));
            }

            Components = new double[vector.Components.Length];
            Array.Copy(vector.Components, Components, vector.Components.Length);

        }

        public Vector(double[] array)
        {
            if (array.Length == 0)

            {
                throw new ArgumentException("длинна массива должна быть > 0", nameof(array.Length));
            }

            Components = new double[array.Length];

            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)

            {
                throw new ArgumentException("n должно быть > 0", nameof(n));
            }

            if (array.Length == 0)

            {
                throw new ArgumentException("длинна массива должна быть > 0", nameof(array.Length));
            }

            Components = new double[n];

            for (int i = 0; i < n - 1; i++)
            {
                if (i >= array.Length)
                {
                    Components[i] = 0;
                }
                else
                {
                    Components[i] = array[i];
                }
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            if (Components == null)
            {
                return "{ }";
            }
            else
            {
                foreach (int e in Components)
                {
                    sb.Append(e + ", ");
                }
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }

        public Vector GetSumVector(Vector vector)
        {
            if (Components.Length == vector.Components.Length)
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    Components[i] = Components[i] + vector.Components[i];
                }
                return this;
            }
            else if (Components.Length > vector.Components.Length)
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    if (i >= vector.Components.Length)
                    {
                        Components[i] = Components[i];
                    }
                    else
                    {
                        Components[i] = Components[i] + vector.Components[i];
                    }
                }
                return this;
            }
            else
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    if (i < Components.Length)
                    {
                        Components[i] = Components[i] + vector.Components[i];
                    }
                    else
                    {
                        Components[i] = vector.Components[i];
                    }
                }
                return this;
            }
        }

        public Vector GetDifferenceVector(Vector vector)
        {
            if (Components.Length == vector.Components.Length)
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    Components[i] = Components[i] - vector.Components[i];
                }
                return this;
            }
            else if (Components.Length > vector.Components.Length)
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    if (i >= vector.Components.Length)
                    {
                        Components[i] = Components[i];
                    }
                    else
                    {
                        Components[i] = Components[i] - vector.Components[i];
                    }
                }
                return this;
            }
            else
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    if (i < Components.Length)
                    {
                        Components[i] = Components[i] - vector.Components[i];
                    }
                    else
                    {
                        Components[i] = 0 - vector.Components[i];
                    }
                }

                return this;
            }
        }

        public Vector GetMultipliedScalar(double scalar)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] = Components[i] * scalar;
            }

            return this;
        }

        public Vector Expand()
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] = Components[i] * -1;
            }

            return this;
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
            if (index < 0 || index > Components.Length)

            {
                throw new ArgumentException("index должно быть от 0 до " + Components.Length, nameof(index));
            }

            return Components[index];
        }

        public void SetComponents(int index, double component)
        {
            if (index < 0 || index > Components.Length)

            {
                throw new ArgumentException("index должно быть от 0 до " + Components.Length, nameof(index));
            }

            Components[index] = component;
        }

        bool IsArrayCompare(double[] a, double[] b)
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

            return IsArrayCompare(Components, p.Components);
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
            return vector1.GetSumVector(vector2);
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            return vector1.GetDifferenceVector(vector2);
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double sum = 0;

            if (vector1.Components.Length == vector2.Components.Length)
            {
                for (int i = 0; i < vector1.Components.Length; i++)
                {
                    sum += vector1.Components[i] * vector2.Components[i];
                }
                return sum;
            }
            else if (vector1.Components.Length > vector2.Components.Length)
            {
                for (int i = 0; i < vector1.Components.Length; i++)
                {
                    if (i < vector2.Components.Length)
                    {
                        sum += vector1.Components[i] * vector2.Components[i];
                    }
                }

                return sum;
            }
            else
            {
                for (int i = 0; i < vector2.Components.Length; i++)
                {
                    if (i < vector1.Components.Length)
                    {
                        sum += vector1.Components[i] * vector2.Components[i];
                    }
                }

                return sum;
            }
        }
    }
}

