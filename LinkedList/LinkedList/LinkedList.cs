using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T>:IEnumerable<T>
    {
        Node<T> Tail;
        Node<T> Head;
        int count;
        
        public void Add(T Data)
        {
            Node<T> node = new Node<T>(Data);
            if (Head==null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            count++;
        }

        public bool Remove(T Data)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            while (current !=null)
            {
                if (current.Data.Equals(Data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head==null)
                        {
                            Tail = null;
                        }
                        
                    }
                    count--;
                    return true;
                    
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public bool Contains(T Data)
        {
            Node<T> current = Head;
            while (current!=null)
            {
                if (current.Data.Equals(Data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        private void AppendFirst(T Data)
        {
            Node<T> node= new Node<T>(Data);
            node.Next = Head;
            Head = node;
            if (count==0)
            {
                Tail = Head;
            }
            count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
