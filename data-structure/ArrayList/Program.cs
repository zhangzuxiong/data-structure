using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayList list = new MyArrayList();
            list.Add(1);
            list.Add("hello");
            list.Add(false);
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
        }
    }

    interface IMyArrayList
    {
        void Add(object obj);

        void RemoveAt(int index);
        object this[int index]
        {
            get;
            set;
        }
        int Count
        {
            get;
        }
    }

    class MyArrayList : IMyArrayList
    {
        object[] data;
        int count;
        public MyArrayList()
        {
            data = new object[4];
            count = 0;
        }

        public object this[int index]
        {
            get
            {
                if (index<0||index>=count)
                {
                    throw new Exception("下标越界");
                }

                for (int i = 0; i < count; i++)
                {
                    if (i==index)
                    {
                        return data[i];
                    }
                }
                return null;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new Exception("下标越界");
                }

                for (int i = 0; i < count; i++)
                {
                    if (i == index)
                    {
                        data[i] = value;
                        return;
                    }
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


        public void Add(object obj)
        {
            if (count>=data.Length)
            {
                object[] newData = new object[data.Length];
                Array.Copy(data, 0, newData, 0, data.Length);
                data = newData;
            }
            data[count++] = obj;
        }

        public void RemoveAt(int index)
        {
            if (index<0||index>=count)
            {
                throw new Exception("下标越界");
            }
            Array.Copy(data, index + 1, data, index, count - index - 1);
            count--;
        }
    }
}
