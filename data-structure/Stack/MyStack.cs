using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{

    class Node<T>
    {
        T value;
        Node<T> pre;
        Node<T> next;

        public Node<T> Pre
        {
            get
            {
                return pre;
            }
            set
            {
                pre = value;
            }
        }
        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        public Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                this.next = value;
            }
        }

        public Node()
        {
            value = default;
            next = null;
            pre = null;
        }

        public Node(T data)
        {
            value = data;
            next = null;
            pre = null;
        }
    }

    class Stack<T> : IStack<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public Stack()
        {
            head = new Node<T>();
            tail = head;
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T Peek()
        {
            if (count==0)
            {
                throw new Exception("栈为空无法得到栈顶元素");
            }
            T res = tail.Value;
            return res;
        }

        public T Pop()
        {
            T res = Peek();
            Node<T> pre = tail.Pre;
            pre.Next = null;
            //tail.Pre = null;
            tail = pre;
            count--;
            return res;
        }

        public void Push(T t)
        {
            Node<T> newNode = new Node<T>(t);
            tail.Next = newNode;
            newNode.Pre = tail;
            tail = newNode;
            count++;
        }
    }
}
