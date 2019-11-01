using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }

    interface IQueue<T>
    {
        //增
        void Enqueue(T t);

        //删
        T Dequeue();

        //队顶元素
        T Peek();
        
        
        //元素个数
        int Count
        {
            get;
        }
    }

    class MyQueue<T> : IQueue<T>
    {
        T[] data;
        int head;
        int tail;

        public MyQueue()
        {
            data = new T[4];
            head = 0;
            tail = 0;
        }

        public int Count
        {
            get
            {
                return head - tail;
            }
        }

        public T Dequeue()
        {
            T t = Peek();
            tail++;
            return t;
        }

        public void Enqueue(T t)
        {
            if (head>=data.Length)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, 0, newData, 0, data.Length);
                data = newData;
            }
            data[head] = t;
            head++;
        }

        public T Peek()
        {
            if (Count<=0)
            {
                throw new Exception("空无法出队");
            }

            return data[tail];

        }
    }
}
