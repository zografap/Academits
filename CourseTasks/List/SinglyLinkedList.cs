using System;
using System.Text;

namespace List
{
    public class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }

        public int Count { get; private set; }

        public SinglyLinkedList() { }

        public T GetFirstElementValue()
        {
            if (Count == 0 || Head == null)
            {
                throw new ArgumentException("В списке нет элементов");
            }
            return Head.Data;
        }

        private ListItem<T> IterateToIndex(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }
            else
            {
                int n = 0;
                ListItem<T> result = Head;

                for (ListItem<T> p = Head; p != null; p = p.Next)
                {
                    if (n == index)
                    {
                        result = p;
                    }
                    n++;
                }
                return result;
            }
        }

        public T GetValueByIndex(int index)
        {
            return IterateToIndex(index).Data;
        }

        public T ChangeElementByIndex(int index, T data)
        {
            T oldValue = default(T);
            oldValue = IterateToIndex(index).Data;
            IterateToIndex(index).Data = data;

            return oldValue;
        }

        public T DeleteItemByIndex(int index)
        {
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            T oldValue = default(T);

            if (Count == 1)
            {
                oldValue = Head.Data;
                Head = null;
            }

            if (index == 0 && Count != 1)
            {
                oldValue = Head.Data;
                Head = Head.Next;
            }

            if (index == 1 && Count == 2)
            {
                oldValue = Head.Next.Data;
                Head.Next = null;
            }

            if (index > 0 && index <= Count - 1 && Count > 2)
            {
                oldValue = IterateToIndex(index).Data;
                IterateToIndex(index - 1).Next = IterateToIndex(index + 1);
            }

            Count--;

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
            if (index > Count - 1 || index < 0)
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
                if (Equals(data, p.Data))
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
            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

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
                ListItem<T> end = IterateToIndex(Count - 1);
                end.Next = listItem;
            }
            Count++;
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copyList = new SinglyLinkedList<T> { };

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
            {
                ListItem<T> listItem = new ListItem<T>(p.Data);
                copyList.InsertElementToBeginning(listItem.Data);
                copyList.Head = prev;
                copyList.Count++;
            }

            copyList.InsertElementToBeginning(Head.Data);
            copyList.Count++;

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
