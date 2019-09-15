using System;
using System.Text;

namespace List
{
    public class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }

        public int Count { get; private set; }

        public T GetFirstElementValue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException ("В списке нет элементов");
            }

            return Head.Data;
        }

        private ListItem<T> IterateToIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            int n = 0;
            ListItem<T> result = Head;

            for (ListItem<T> p = Head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    result = p;
                    break;
                }
                n++;
            }

            return result;
        }

        public T GetValueByIndex(int index)
        {
            return IterateToIndex(index).Data;
        }

        public T ChangeElementByIndex(int index, T data)
        {
            ListItem<T> item = IterateToIndex(index);
            T oldValue = item.Data;
            item.Data = data;

            return oldValue;
        }

        public T DeleteItemByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index выходит за границы списка");
            }

            Count--;

            if (index == 0)
            {
                Head = Head.Next;
                return Head.Data;
            }

            ListItem<T> prev = IterateToIndex(index - 1);
            ListItem<T> temp = prev.Next;

            prev.Next = temp.Next;

            return temp.Data;
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

            if (index == 0)
            {
                InsertElementToBeginning(data);
            }
            else
            {
                ListItem<T> prev = IterateToIndex(index - 1);
                ListItem<T> listItem = new ListItem<T>(data);
                listItem.Next = prev.Next;
                prev.Next = listItem;
                Count++;
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
            InsertElementByIndex(Count, data);
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copyList = new SinglyLinkedList<T> { };

            if (Count == 0)
            {
                return copyList;
            }

            copyList.InsertElementToBeginning(Head.Data);

            for (ListItem<T> p = Head.Next, prev = copyList.Head; p != null; prev = prev.Next, p = p.Next)
            {
                prev.Next = new ListItem<T>(p.Data);
            }


            copyList.Count = Count;

            return copyList;

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Count == 0)
            {
                sb.Append("{ }");

                return sb.ToString();
            }

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
