using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        public int Сapacity { get; set; }

        private List<T>[] ArrayHashTable = new List<T>[10];

        private List<T> ListItem;

        public int Count { get; set; }

        public HashTable()
        {
            Сapacity = 10;
            ArrayHashTable = new List<T>[Сapacity];
                
            for (int i = 0; i < Сapacity; ++i)
            {
                ArrayHashTable[i] = null;
            }
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
            int index = Math.Abs(item.GetHashCode() % Сapacity);

            //if (Equals(ArrayHashTable[index], null))
            //{
                List < T > list = new List<T>();
                list.Add(item);
            list = ArrayHashTable[index];
            //}

            //if (ArrayHashTable[index].IndexOf(item) == -1)
            //{
            //    ArrayHashTable[index].Add(item);
            //    Count++;
            //}
            //else
            //{
            //    throw new ArgumentException("Хеш-таблица уже содержит такой элемент");
            //}

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
