using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int count;

        public SinglyLinkedList() { }

        public int GetSize()
        {
            return count;
        }

        public ListItem<T> GetValueFirstElement()
        {
            return head;
        }

        public ListItem<T> GetValueByIndex(int index)
        {
            if (index > count)
            {
                throw new ArgumentException("index выходит за границы списка");
            }

            int n = 0;

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                if (n == index)
                {
                    return p;
                }
                n++;
            }
            return null;
        }

        public void InsertElementToBeginning(T Data)
        {

        } 
    }
}
