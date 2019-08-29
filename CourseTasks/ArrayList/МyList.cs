using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class МyList<T> : IList<T>
    {
        public int Сapacity { get; set; }

        private int ModCount;

        private T[] Contents;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                return Contents[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                Contents[index] = value;
            }
        }

        public int Count { get; private set; }

        public МyList()
        {
            Count = 0;
            Сapacity = 10;
            ModCount = 0;
            Contents = new T[Сapacity];
        }

        public void TrimExcess()
        {
            Array.Resize(ref Contents, Count);
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T data)
        {
            if (Count >= Contents.Length)
            {
                T[] contentsTmp = new T[Сapacity * 2];
                Array.Copy(Contents, 0, contentsTmp, 0, Contents.Length);
                Contents = contentsTmp;
            }

            Contents[Count] = data;
            Count++;
            ModCount++;
        }

        public void Clear()
        {
            Count = 0;
            TrimExcess();
            ModCount++;
        }

        public bool Contains(T data)
        {
            return Array.Exists(Contents, element => Equals(element, data));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("целевой массив не может быть null");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("индекс должен быть от 0 до " + (array.Length - 1));
            }

            if (Contents.Length > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException("Измените входные данные, копируемый массив не помещается");
            }

            Array.Copy(Contents, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = ModCount;

            for (int i = 0; i < Contents.Length; ++i)
            {
                if (modCount != ModCount)
                {
                    throw new InvalidOperationException("Список был изменен!");
                }

                yield return Contents[i];
            }
        }

        public int IndexOf(T data)
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                if (Equals(data, Contents[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T data)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            Count++;
            ModCount++;
            T[] contentsTmp = new T[Сapacity];

            if (Count >= Contents.Length)
            {
                contentsTmp = new T[Сapacity * 2];
            }

            Array.Copy(Contents, 0, contentsTmp, 0, Contents.Length);

            if ((Count + 1 <= Contents.Length) && (index < Count) && (index >= 0) || (index == 0))
            {
                Array.Copy(Contents, index, contentsTmp, index + 1, Contents.Length);
                Contents = contentsTmp;
                Contents[index] = data;
            }

            Contents = contentsTmp;
            Contents[index] = data;
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveAt(IndexOf(item));

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            if (index + 1 < Count)
            {
                Array.Copy(Contents, index + 1, Contents, index, Count - index + 1);
            }

            Count--;
            ModCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Contents.Length == 0)
            {
                sb.Append("{ }");

                return sb.ToString();
            }

            sb.Append("{ ");

            foreach (T e in Contents)
            {
                sb.Append(e);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
