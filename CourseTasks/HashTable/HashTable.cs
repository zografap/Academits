using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        public int Сapacity { get; private set; }

        public List<T>[] ArrayHashTable;

        public int Count { get; private set; }

        private int modCount;

        public HashTable()
        {
            Сapacity = 10;
            ArrayHashTable = new List<T>[Сapacity];

            for (int i = 0; i < Сapacity; ++i)
            {
                ArrayHashTable[i] = new List<T>() { };
            }

            Count = 0;
            modCount = 0;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            int index = Math.Abs(item.GetHashCode() % Сapacity);

            if (ArrayHashTable[index].IndexOf(item) == -1)
            {
                ArrayHashTable[index].Add(item);
                Count++;
                modCount++;
            }
            else
            {
                throw new ArgumentException("Хеш-таблица уже содержит такой элемент");
            }
        }

        public void Clear()
        {
            foreach (List<T> e in ArrayHashTable)
            {
                e.Clear();
            }

            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            int index = Math.Abs(item.GetHashCode() % ArrayHashTable.Length);

            if (ArrayHashTable[index].IndexOf(item) == -1)
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

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException("Измените входные данные, копируемые данные не помещаются");
            }

            int index = arrayIndex;

            foreach (List<T> e in ArrayHashTable)
            {
                Array.Copy(e.ToArray(), 0, array, index, e.Count);
                index += e.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCount = this.modCount;

            for (int i = 0; i < Сapacity; ++i)
            {
                if (ArrayHashTable[i].Count == 0)
                {
                    continue;
                }
                else
                {
                    for (int k = 0; k < ArrayHashTable[i].Count; ++k)
                    {
                        if (modCount != this.modCount)
                        {
                            throw new InvalidOperationException("Таблица была изменена!");
                        }

                        yield return ArrayHashTable[i][k];
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                int index = Math.Abs(item.GetHashCode() % ArrayHashTable.Length);
                ArrayHashTable[index].Remove(item);
                Count--;
                modCount++;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Count == 0)
            {
                sb.Append("{ }");

                return sb.ToString();
            }

            foreach (List<T> e in ArrayHashTable)
            {
                if (e.Count == 0)
                {
                    sb.Append("{ }" + Environment.NewLine);
                }

                sb.Append("{ ");

                foreach (T i in e)
                {
                    sb.Append(i.ToString());
                    sb.Append(", ");
                }

                sb.Remove(sb.Length - 2, 2);

                if (e.Count != 0)
                {
                    sb.Append(" }" + Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}
