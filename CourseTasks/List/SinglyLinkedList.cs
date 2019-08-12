using System;
using System.Text;

namespace List
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }
        private int Count { get; set; }

        public SinglyLinkedList() { }

        public int GetSize()
        {
            return Count;
        }

        public T GetValueFirstElement()
        {
            return Head.Data;
        }

        public T GetValueByIndex(int index)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            int n = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    return p.Data;
                }
                n++;
            }
            return default(T);
        }

        public T ChangeElementByIndex(int index, T data)
        {
            T oldValue = GetValueByIndex(index);
            int n = 0;

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    p.Data = data;
                }
                n++;
            }

            return oldValue;
        }

        public T DeleteItemByIndex(int index)
        {
            T oldValue = GetValueByIndex(index);
            int n = 0;

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (n == index)
                {
                    prev.Next = p.Next;
                    Count--;
                }
                n++;
            }

            return oldValue;
        }

        public void InsertElementToBeginning(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data);
            listItem.Next = Head;
            Head = listItem;
            Count++;
        }

        public void InsertElementByIndex(T data, int index)
        {
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
                if (p.Data.Equals(data))
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
            ListItem<T> prev = null, current = Head, next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        public SinglyLinkedList<T> Сopy()
        {
            SinglyLinkedList<T> copyList = new SinglyLinkedList<T> { };

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                copyList.InsertElementToBeginning(p.Data);
            }

            copyList.Reverse();

            return copyList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                sb.Append(p.Data);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
