using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private static int Сapacity = 10;

        private List<T>[] ArrayHashTable;

        private List<T> ListItem ;

        public int Count { get; set; }

        public HashTable()
        {
            List<T>[] ArrayHashTable = new List<T>[Сapacity];
            Count = 0;
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
            int index = Math.Abs(item.GetHashCode() % ArrayHashTable.Length);

            if (ArrayHashTable[index] == null)
            {
                ArrayHashTable[index] = new List<T> { item };
                Count++;
            }
            else
            {
                if (ArrayHashTable[index].IndexOf(item) == -1)
                {
                    ArrayHashTable[index].Add(item);
                    Count++;
                }
                else
                {
                    throw new ArgumentException("Хеш-таблица уже содержит такой элемент");
                }
            }
        }

        public void Clear()
        {
            foreach (List<T> e in ArrayHashTable)
            {
                e.Clear();
            }

            Count = 0;
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
