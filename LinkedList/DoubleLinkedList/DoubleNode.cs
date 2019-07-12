using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.DoubleLinkedList
{
    class DoubleNode<T>
    {
        public DoubleNode(T Data)
        {
            this.Data = Data;
        }
        public T Data { get;set; }
        public DoubleNode<T> Next { get; set; }
        public DoubleNode<T> Previous { get; set; }
    }
}
