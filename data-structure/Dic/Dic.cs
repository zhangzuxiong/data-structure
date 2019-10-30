using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dic
{
    class Node<Key, Value>
    {
        Key k;
        Value v;
        Node<Key, Value> pre;
        Node<Key, Value> next;

        public Key K
        {
            get
            {
                return k;
            }
            set
            {
                k = value;
            }
        }

        public Value V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }
        
        public Node<Key,Value> Pre
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

        public Node<Key,Value> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        public Node()
        {
            k = default;
            v = default;
            pre = null;
            next = null;
        }

        public Node(Key k,Value v)
        {
            this.k = k;
            this.v = v;
            pre = null;
            next = null;
        }
    }

    public class MyDicitonary<Key, Value> : IDicitonary<Key, Value>
    {
        Node<Key, Value> head;
        Node<Key, Value> tail;
        int count;

        public MyDicitonary()
        {
            head = new Node<Key, Value>();
            tail = new Node<Key, Value>();
            head.Next = tail;
            tail.Pre = head;
            count = 0;
        }

        public Value this[Key key]
        {
            get
            {
                int index = GetIndexByKey(key);
                if (index==-1)
                {
                    throw new Exception("不存在这个键");
                }

                Node<Key, Value> node = head;
                while (index>=0)
                {
                    node = node.Next;
                    index--;
                }
                return node.V;
            }
            set
            {
                int index = GetIndexByKey(key);
                if (index != -1)
                {
                    Node<Key, Value> node = head;
                    while (index >= 0)
                    {
                        node = node.Next;
                        index--;
                    }
                    node.V = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        int GetIndexByKey(Key key)
        {
            int index = 0;
            Node<Key, Value> node = head;

            while (!node.Next.Equals(tail))
            {
                if (node.Next.K.Equals(key))
                {
                    return index;
                }
                node = node.Next;
                index++;
            }
            return -1;
        }

        bool ContainsKey(Key key)
        {
            return GetIndexByKey(key) != -1;
        }

        public void Add(Key key, Value value)
        {
            if (ContainsKey(key))
            {
                throw new Exception("已经包含这个键");
            }
            Node<Key, Value> node = new Node<Key, Value>(key, value);

            node.Pre = tail.Pre;
            tail.Pre = node;
            node.Pre.Next = node;
            node.Next = tail;

            count++;
        }

        public void Remove(Key key)
        {
            int index = GetIndexByKey(key);
            if (index!=-1)
            {
                Node<Key, Value> node = head;
                while (index>=0)
                {
                    node = node.Next;
                    index--;
                }
                node.Pre.Next = node.Next;
                node.Next.Pre = node.Pre;

                count--;
            }
        }
    }
}
