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

        public ListItem<T> GetValueFirstElement()
        {
            return Head;
        }

        public ListItem<T> GetValueByIndex(int index)
        {
            if (index > Count)
            {
                throw new ArgumentException("index выходит за границы списка");
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

        public ListItem<T> ChangeElementByIndex(int index, T data)
        {
            ListItem<T> p = GetValueByIndex(index);
            p.Data = data;
            return null;
        }

        public void InsertElementToBeginning(T Data)
        {
            ListItem<T> listItem = new ListItem<T>(Data);
            listItem.Next = Head;
            Head = listItem;
            Count++;
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
