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
            if (Count == 0)
            {
                throw new ArgumentException("В списке нет элементов");
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

            if (Count == 0)
            {
                throw new Exception("Список пуст");
            }

            Count--;

            if (Head != null && index < Count && index >= 0)
            {
                ListItem<T> temp = Head;
                ListItem<T> pref = Head;

                for (int i = 0; i < index; i++)
                {
                    pref = temp;
                    temp = temp.Next;
                }

                if (temp == Head)
                {
                    Head = temp.Next;

                    return temp.Data;
                }
                else
                {
                    pref.Next = temp.Next;

                    return temp.Data;
                }
            }

            return default(T);
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
            else if (index == Count)
            {
                ListItem<T> prev = IterateToIndex(index - 1);
                ListItem<T> listItem = new ListItem<T>(data);
                prev.Next = listItem;
                Count++;
            }
            else
            {
                ListItem<T> listItem = new ListItem<T>(data);
                ListItem<T> prev = IterateToIndex(index - 1);
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
            else
            {
                for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.Next)
                {
                    ListItem<T> listItem = new ListItem<T>(p.Data);
                    copyList.InsertElementToBeginning(listItem.Data);
                    copyList.Head = prev;
                }

                copyList.InsertElementToBeginning(Head.Data);
                copyList.Count = Count;

                return copyList;
            }
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
