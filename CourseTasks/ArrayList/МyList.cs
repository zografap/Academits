using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class МyList<T> : IList<T>
    {
        private static int Сapacity = 10;

        private ListItem<T>[] Contents = new ListItem<T>[Сapacity];

        public T this[int index]
        {
            get
            {
                return Contents[index].Data;
            }
            set
            {
                Contents[index].Data = value;
            }
        }

        public int Count { get; set; }

        public МyList(int capacity)
        {
            Contents = new ListItem<T>[Сapacity];
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity <= Contents.Length)
            {
                throw new ArgumentException("вместимость должна быть больше " + Contents.Length);
            }
            else
            {
                ListItem<T>[] ContentsTmp = new ListItem<T>[capacity];
                Array.Copy(Contents, 0, ContentsTmp, 0, Contents.Length);
                Contents = ContentsTmp;
            }
        }

        public void TrimToSize()
        {
            ListItem<T>[] ContentsTmp = new ListItem<T>[Count];
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
            ListItem<T> listItem = new ListItem<T>(data);

            if (Count < Contents.Length)
            {

                Contents[Count] = listItem;
                Count++;
            }
            else
            {
                ListItem<T>[] ContentsTmp = new ListItem<T>[Сapacity * 2];
                Array.Copy(Contents, 0, ContentsTmp, 0, Contents.Length);
                Contents = ContentsTmp;
                Contents[Count] = listItem;
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
                if (Contents[i].Data.Equals(data))
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

                for (int i = Count - 1; i > index; i--)
                {
                    Contents[i] = Contents[i - 1];
                }

                Contents[index].Data = data;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            for (int i = 0; i < Count; i++)
            {
                sb.Append(Contents[i].Data);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
