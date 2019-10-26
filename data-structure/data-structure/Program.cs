using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数组实现列表:");
            TestListArray();

            Console.WriteLine("\n\n单链表实现列表:");
            TestLinkList();

            Console.WriteLine("\n\n双链表实现列表:");
            TestDoubleLinkList();

        }

        static void TestLinkList()
        {
            LinkList<int> list = new LinkList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(2, 1);
            list.Add(1);
            Console.WriteLine(list[1]);
            list.RemoveAll(1);
            Console.WriteLine(list);
            list.Insert(1, 1);
            list.Insert(1, 2);
            list.Insert(3, 1);
            Console.WriteLine(list);
            list.RemoveAll(1);
            Console.WriteLine(list.Count);
            Console.WriteLine(list);

        }

        static void TestDoubleLinkList()
        {
            DoubleLinkList<int> list = new DoubleLinkList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(2, 1);
            list.Add(1);
            Console.WriteLine(list[1]);
            list.RemoveAll(1);
            Console.WriteLine(list);
            list.Insert(1, 1);
            list.Insert(1, 2);
            list.Insert(3, 1);
            Console.WriteLine(list);
            list.RemoveAll(1);
            Console.WriteLine(list.Count);
            Console.WriteLine(list);
        }

        static void TestListArray()
        {
            ArrayList<int> list = new ArrayList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(2, 1);
            list.Add(1);
            Console.WriteLine(list[1]);
            list.RemoveAll(1);
            Console.WriteLine(list);
            list.Insert(1, 1);
            list.Insert(1, 2);
            list.Insert(3, 1);
            Console.WriteLine(list);
            list.RemoveAll(1);
            Console.WriteLine(list.Count);
            Console.WriteLine(list);


            //ArrayList<int> list = new ArrayList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //list.Insert(1, 3);
            //list.Print();
            ///*list.Remove(1);
            //list.RemoveAt(1);
            //list.RemoveAll(3);*/
            //Console.WriteLine("ToArray");

            //int[] result = list.ToArray();

            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.Write(result[i] + "\t");
            //}
            //Console.WriteLine("\nToArray");

            //Console.WriteLine(list[0]);
            ////Console.WriteLine(list[1]);
            ////Console.WriteLine(list);
            //list.Print();

            /*List<int> list = new List<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Sort(MySort);*/
        }

        //排序
        public static int MySort(int n1,int n2)
        {
            if (n1>n2)
            {
                return 1;
            }
            if (n1==n2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}

