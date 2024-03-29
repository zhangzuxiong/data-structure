﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{

    //节点
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node()
        {
            //default关键字用于表明一个类型的默认值，枚举类型是第一项，结构体是所有字段为default
            data = default(T);
            next = null;
        }
        public Node(T data)
        {
            this.data = data;
            next = null;
        }

    }
    interface ILinkList<T>
    {
        //增
        void Add(T t);
        void Insert(int index, T data);//插入一个元素到指定的下标位置

        //删
        void Remove(T t);
        void RemoveAt(int index);//根据下标去删除一个元素
        void RemoveAll(T t);//删除这个容器中所有与这个元素相同的元素

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

    public class LinkList<T> : ILinkList<T>
    {
        Node<T> head;//头结点
        int count;//有效节点元素

        public int Count
        {
            get
            {
                return count;
            }
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
                Node<T> node = head;
                for (int i = 0; i <= index; i++)
                {
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
                Node<T> node = head;
                for (int i = 0; i <= index; i++)
                {
                    node = node.next;
                }
                node.data = value;
            }
        }

        public LinkList()
        {
            head = new Node<T>();
            count = 0;
        }


        /// <summary>
        /// 在链表末尾插入一个元素
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            Node<T> temp = new Node<T>(t);
            Node<T> node = head;
            while (node.next!=null)
            {
                node = node.next;
            }
            node.next = temp;
            count++;
        }

        /// <summary>
        /// 删除链表中指定的第一个元素
        /// </summary>
        /// <param name="t"></param>
        public void Remove(T t)
        {
            Node<T> node = head;
            Node<T> pre = node;
            while (node.next!=null)
            {
                if (node.data.Equals(t))
                {
                    pre.next = node.next;
                    count--;
                    return;
                }

                pre = node;
                node = node.next;
            }
        }

        /// <summary>
        /// 在指定的位置插入一个元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Insert(int index, T data)
        {
            if (index < 0 || index > count)
            {
                throw new Exception("下标越界");
            }
            //插入的节点
            Node<T> node = head;
            //插入的前面一个节点
            Node<T> pre = node;
            for (int i = 0; i <= index; i++)
            {
                pre = node;
                node = node.next;
            }
            Node<T> temp = new Node<T>(data);
            temp.next = node;
            pre.next = temp;
            count++;
        }

        /// <summary>
        /// 删除指定下标的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count )
            {
                throw new Exception("下标越界");
            }
            int i = 0;
            Node<T> node = head;
            while (i<index)
            {
                node = node.next;
                i++;
            }
            node.next = node.next.next;
            count--;

        }

        /// <summary>
        /// 获取指定数据的下标
        /// </summary>
        /// <param name="t"></param>
        /// <returns>如果找到了返回下标，否则返回-1</returns>
        int GetIndexByValue(T t)
        {
            Node<T> node = head;
            int i = 0;
            while (node.next!=null)
            {
                if (node.next.data.Equals(t))
                {
                    return i;
                }

                i++;
                node = node.next;
            }
            return -1;
        }

        /// <summary>
        /// 删除链表中指定的所有元素
        /// </summary>
        /// <param name="t"></param>
        public void RemoveAll(T t)
        {
            int index = GetIndexByValue(t);
            if (index==-1)
            {
                return;
            }
            RemoveAt(index);
            RemoveAll(t);
        }

        /// <summary>
        /// 链表转数组
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] data = new T[count];
            int i = 0;
            Node<T> index = head.next;
            while (index!=null)
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
