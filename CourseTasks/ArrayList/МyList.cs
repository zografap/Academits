using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class МyList<T> : IList<T>
    {
        public int Capacity { get; private set; }

        private int modCount;

        private T[] contents;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                return contents[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("index выходит за границы списка");
                }

                contents[index] = value;
            }
        }

        public int Count { get; private set; }

        public МyList()
        {
            Count = 0;
            Capacity = 10;
            modCount = 0;
            contents = new T[Capacity];
        }

        public void TrimExcess()
        {
            Array.Resize(ref contents, Count);
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
            if (Count >= contents.Length)
            {
                Array.Resize(ref contents, Count + 1);
            }

            contents[Count] = data;
            Count++;
            modCount++;
        }

        public void Clear()
        {
            Count = 0;

            for (int i = 0; i < contents.Length; ++i)
            {
                contents[i] = default(T);
            }

            modCount++;
        }

        public bool Contains(T data)
        {
            if (IndexOf(data) == -1)
            {
                return false;
            }

            return true;
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

            if (contents.Length > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException("Измените входные данные, копируемый массив не помещается");
            }

            Array.Copy(contents, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = this.modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (modCount != this.modCount)
                {
                    throw new InvalidOperationException("Список был изменен!");
                }

                yield return contents[i];
            }
        }

        public int IndexOf(T data)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(data, contents[i]))
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
            modCount++;
            T[] contentsTmp = new T[Capacity];

            if (Count >= contents.Length)
            {
                contentsTmp = new T[Capacity * 2];
            }

            Array.Copy(contents, 0, contentsTmp, 0, contents.Length);

            if ((Count + 1 <= contents.Length) && (index < Count) && (index >= 0) || (index == 0))
            {
                Array.Copy(contents, index, contentsTmp, index + 1, contents.Length);
                contents = contentsTmp;
                contents[index] = data;
            }

            contents = contentsTmp;
            contents[index] = data;
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
                Array.Copy(contents, index + 1, contents, index, Count - index - 1);
            }

            Count--;
            modCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (contents.Length == 0)
            {
                sb.Append("{ }");

                return sb.ToString();
            }

            sb.Append("{ ");

            foreach (T e in contents)
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
