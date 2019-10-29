using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
        }


        //大数相加
        static string BigNumAdd(string num1, string num2)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            //入栈是为了进行右对齐相加的操作
            for (int i = 0; i < num1.Length; i++)
            {
                stack1.Push(num1[i] - '0');
            }
            for (int i = 0; i < num2.Length; i++)
            {
                stack2.Push(num2[i] - '0');
            }

            Stack<int> resultStack = new Stack<int>();
            bool carry = false;//是否进位
            int loopCount = (stack1.Count > stack2.Count ? stack1.Count : stack2.Count) + 1;//循环次数
            for (int i = 0; i < loopCount; i++)
            {
                int addNum1 = stack1.Count > 0 ? stack1.Pop() : 0;
                int addNum2 = stack2.Count > 0 ? stack2.Pop() : 0;
                int result = addNum1 + addNum2 + (carry ? 1 : 0);
                resultStack.Push(result % 10);
                carry = result > 9;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; resultStack.Count > 0; i++)
            {
                if (i == 0 && resultStack.Peek() == 0)
                {
                    resultStack.Pop();
                    continue;
                }
                sb.Append(resultStack.Pop());
            }
            return sb.ToString();
        }

    }


    interface IStack<T>
    {
        //入栈
        void Push(T t);

        //出栈
        T Pop();

        //栈顶元素
        T Peek();
        
        
        //元素个数
        int Count
        {
            get;
        }
    }

    /*class Stack<T> : IStack<T>
    {
        T[] data;
        int count;

        public Stack()
        {
            data = new T[4];
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
            if (count <= 0)
            {
                throw new Exception("栈为空没有栈元素");
            }
            return data[count - 1];
        }

        public T Pop()
        {
            T res = Peek();
            count--;
            return res;
        }

        public void Push(T t)
        {
            if (count >= data.Length)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, 0, newData, 0, data.Length);
                data = newData;
            }
            data[count] = t;
            count++;
        }
    }*/
}
