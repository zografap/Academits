using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }
        public int Count { get; set; }

        public SinglyLinkedList() { }

        public T GetValueFirstElement()
        {
            if (Count == 0 || Head == null)
            {
                throw new ArgumentException("В списке нет элементов");
            }
            return Head.Data;
        }

        private ListItem<T> IterateToIndex(int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            int n = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    return p;
                }
                n++;
            }

            return null;
        }

        public T GetValueByIndex(int index)
        {
            return IterateToIndex(index).Data;
        }

        public T ChangeElementByIndex(int index, T data)
        {
            T oldValue = default(T);
            int n = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    oldValue = p.Data;
                    p.Data = data;
                }
                n++;
            }

            return oldValue;
        }

        public T DeleteItemByIndex(int index)
        {
            T oldValue = default(T);
            int n = 0;

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (n == index)
                {
                    oldValue = p.Data;
                    prev.Next = p.Next;
                    Count--;
                }
                n++;
            }

            return oldValue;
        }

        public void InsertElementToBeginning(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data, Head);
            Head = listItem;
            Count++;
        }

        public void InsertElementByIndex(int index, T data)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            ListItem<T> listItem = new ListItem<T>(data);
            int n = 0;

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (n == index)
                {
                    prev.Next = listItem;
                    listItem.Next = p;
                    Count++;
                }
                n++;
            }
        }

        public bool DeleteNodeByValue(T data)
        {
            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (p.Data != null && data != null && p.Data.Equals(data) || p.Data == null && data == null)
                {
                    if (prev != null)
                    {
                        prev.Next = p.Next;
                    }
                    else
                    {
                        Head = Head.Next;
                    }
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T DeleteFirstItem()
        {
            T oldValue = Head.Data;
            Head = Head.Next;
            Count--;
            return oldValue;
        }

        public void Reverse()
        {
            ListItem<T> prev = null;
            ListItem<T> current = Head;

            while (current != null)
            {
                ListItem<T> next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        public void AddToEnd(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data);

            if (Head == null)
            {
                Head = listItem;
            }
            else
            {
                ListItem<T> current = Head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = listItem;
            }
            Count++;
        }

        public SinglyLinkedList<T> Сopy()
        {
            SinglyLinkedList<T> copyList = new SinglyLinkedList<T> { };

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                copyList.AddToEnd(p.Data);
            }

            return copyList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (p.Data == null)
                {
                    sb.Append("null");
                }
                sb.Append(p.Data);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
