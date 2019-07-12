using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.DoubleLinkedList
{
    class DoubleLinkedList<T> : IEnumerable<T>
    {
        DoubleNode<T> Head;
        DoubleNode<T> Tail;
        int count;

        public void Add(T Data)
        {
            DoubleNode<T> node = new DoubleNode<T>(Data);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            count++;
        }

        public void AddFirst(T Data)
        {
            DoubleNode<T> node = new DoubleNode<T>(Data);
            DoubleNode<T> temp = Head;
            node.Next = temp;
            Head = node;
            if (count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = node;
            }
            count++;
        }

        public bool Remove(T data)
        {
            DoubleNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    Tail = current.Previous;
                }
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }
                count--;
                return true;
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
        public bool Contains(T data)
        {
            DoubleNode<T> current = Head;
            while (current!=null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleNode<T> current = Head;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoubleNode<T> current = Tail;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
