using System;

namespace Linklistaction
{
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = null;
            tail = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public static void ForEach(GenericList<T> g, Action<Node<T>> action)
        {
            if (g.isEmpty())
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node<T> n = g.Head;
            while (n != null)
            {
                action(n);
                n = n.Next;
            }
        }
        
        public bool isEmpty()
        {
            return head == null;
        }
        
        
        public void Add(T data)
        {
            Node<T> n = new Node<T>(data);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = tail.Next;
            }
        }
        
    }
}