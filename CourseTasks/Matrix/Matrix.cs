using Vec = Vector.Vector;
namespace Matrix
{
    class Matrix : Vec
    {
        private int M { get; set; }
        public Vec[] MatrixArray { get; set; }

        public Matrix(int n, int m)
        {            
            Vec vector = new Vec(n);
            vector.N = n;

            MatrixArray = new Vec[m];

            for (int i = 0; i < n - 1; i++)
            {
                vector.Array[i] = 0;
            }

            for (int i = 0; i < m - 1; i++)
            {
                MatrixArray[i] = vector;
            }
        }
    }
}
