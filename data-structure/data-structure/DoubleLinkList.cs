using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{

    //节点
    class DoubleNode<T>
    {
        //节点中的具体的数据
        public T data;

        //执行下一个节点
        public DoubleNode<T> next;

        //指向前一个节点
        public DoubleNode<T> pre;


        public DoubleNode()
        {
            next = null;
            pre = null;
        }

        public DoubleNode(T data)
        {
            this.data = data;
            next = null;
            pre = null;
        }

    }

    interface IDoubleLinkList<T>
    {
        //增
        void Add(T data);//增加到当前容器的末尾
        void Insert(int index, T data);//插入一个元素到指定的下标位置

        //删
        void RemoveAt(int index);//根据下标去删除一个元素
        void Remove(T data);//删除一个元素
        void RemoveAll(T data);//删除这个容器中所有与这个元素相同的元素

        //索引器:可以是一个类具有像数组一样的访问形式
        //索引器:查找条件可以有多个参数，参数的类型可以是任意类型
        T this[int index]
        {
            //查
            get;

            //改
            set;
        }

        //元素个数
        int Count
        {
            get;
        }
    }

    public class DoubleLinkList<T> : IDoubleLinkList<T>
    {
        DoubleNode<T> head;//头结点

        DoubleNode<T> tail;//尾节点

        int count;//有效元素个数

        //构造函数初始化
        public DoubleLinkList()
        {
            head = new DoubleNode<T>();
            tail = new DoubleNode<T>();

            //头结点的next指向尾节点
            head.next = tail;

            //尾节点的pre指向头结点
            tail.pre = head;
            count = 0;
        }

        //索引器
        public T this[int index] 
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new Exception("下标越界");
                }
                int i = 0;
                DoubleNode<T> node = head;
                while (i<=index)
                {
                    i++;
                    node = node.next;
                }
                return node.data;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new Exception("下标越界");
                }
                int i = 0;
                DoubleNode<T> node = head;
                while (i <= index)
                {
                    i++;
                    node = node.next;
                }
                node.data = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// 往链表中新添加一个数据
        /// </summary>
        /// <param name="data">新加的数据</param>
        public void Add(T data)
        {
            DoubleNode<T> node = head;
            int i = 0;
            while (node.next!=tail)
            {
                i++;
                node = node.next;
            }
            Insert(i, data);
        }

        /// <summary>
        /// 在指定位置插入一个数据
        /// </summary>
        /// <param name="index">插入的位置</param>
        /// <param name="data">插入的值</param>
        public void Insert(int index, T data)
        {
            if (index < 0 || index > count)
            {
                throw new Exception("下标越界");
            }

            DoubleNode<T> node = head;
            int i = 0;
            while (i<=index)
            {
                node = node.next;
                i++;
            }
            DoubleNode<T> temp = new DoubleNode<T>(data);

            //新节点的pre指向插入节点的pre
            temp.pre = node.pre;

            //插入节点的pre的next指向新节点
            node.pre.next = temp;

            //插入节点的pre的next指向新节点
            node.pre = temp;

            //新节点的next指向插入的节点
            temp.next = node;

            count++;
        }

        /// <summary>
        /// 删除一个数据
        /// </summary>
        /// <param name="data">删除的数据</param>
        public void Remove(T data)
        {
            int index = GetIndexByValue(data);
            if (index!=-1)
            {
                RemoveAt(index);
            }
        }


        /// <summary>
        /// 删除链表中的所有指定的值
        /// </summary>
        /// <param name="data"></param>
        public void RemoveAll(T data)
        {
            int index = GetIndexByValue(data);
            if (index==-1)
            {
                return;
            }
            RemoveAt(index);
            RemoveAll(data);
        }

        /// <summary>
        /// 通过值获取数据的下标
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int GetIndexByValue(T data)
        {
            int i = 0;
            DoubleNode<T> index = head.next;
            while (index!=tail)
            {
                if (index.data.Equals(data))
                {
                    return i;
                }
                index = index.next;
                i++;
            }
            return -1;
        }


        /// <summary>
        /// 删除指定位置的数据
        /// </summary>
        /// <param name="index">删除的下标</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new Exception("下标越界");
            }
            int i = 0;
            DoubleNode<T> node = head;
            while (i<=index)
            {
                node = node.next;
                i++;
            }

            node.pre.next = node.next;
            node.next.pre = node.pre;

            count--;
        }

        /// <summary>
        /// 链表转数组
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] data = new T[count];
            int i = 0;
            DoubleNode<T> index = head.next;
            while (index!=tail)
            {
                data[i++] = index.data;
                index = index.next;
            }
            return data;
        }

        public override string ToString()
        {
            return "[" + string.Join(",", ToArray()) + "]";
        }
    }
}
