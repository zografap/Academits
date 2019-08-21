using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class МyList<T> : IList<T>
    {
        private static int Сapacity = 10;

        private T[] Contents = new T[Сapacity];

        public T this[int index]
        {
            get
            {
                return Contents[index];
            }
            set
            {
                Contents[index] = value;
            }
        }

        public int Count { get; set; }

        public МyList(int capacity)
        {
            Contents = new T[Сapacity];
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity <= Contents.Length)
            {
                throw new ArgumentException("вместимость должна быть больше " + Contents.Length);
            }
            else
            {
                T[] ContentsTmp = new T[capacity];
                Array.Copy(Contents, 0, ContentsTmp, 0, Contents.Length);
                Contents = ContentsTmp;
            }
        }

        public void TrimToSize()
        {
            T[] ContentsTmp = new T[Count];
            Array.Copy(Contents, 0, ContentsTmp, 0, Count);
            Contents = ContentsTmp;
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
            if (Count < Contents.Length)
            {
                Contents[Count] = data;
                Count++;
            }
            else
            {
                T[] ContentsTmp = new T[Сapacity * 2];
                Array.Copy(Contents, 0, ContentsTmp, 0, Contents.Length);
                Contents = ContentsTmp;
                Contents[Count] = data;
                Count++;
            }
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T data)
        {
            bool inList = false;

            for (int i = 0; i < Count; i++)
            {
                if (Contents[i].Equals(data))
                {
                    inList = true;
                    break;
                }
            }

            return inList;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = arrayIndex;

            for (int i = 0; i < Count; i++)
            {
                array.SetValue(Contents[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T data)
        {
            int itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (Contents[i].Equals(data))
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }

        public void Insert(int index, T data)
        {
            if ((Count + 1 <= Contents.Length) && (index < Count) && (index >= 0))
            {
                Count++;
                T tmp = Contents[index];

                for (int i = Count - 1; i > index; i--)
                {
                    Contents[i] = Contents[i - 1];
                }

                Contents[index] = data;
            }
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
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    Contents[i] = Contents[i + 1];
                }

                Count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            for (int i = 0; i < Count; i++)
            {
                sb.Append(Contents[i]);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
