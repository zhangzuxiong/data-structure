using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{
    class ArrayList<T> : IArrayList<T>
    {
        T[] data;
        int count;
        public ArrayList()
        {
            data = new T[4];//C#底层封装的List是4 
            count = 0;
        }

        public T this[int index] 
        { 
            get 
            {
                if (index<0||index>=count)
                {
                    throw new Exception("下标越界");
                }
                return data[index]; 
            }
            set
            {
                if (index<0||index>=count)
                {
                    throw new Exception("下标越界");
                }
                data[index] = value;
            }
        }

        public int Count 
        {
            get
            {
                return count;
            }
        }

        public void Add(T data)
        {
            if (this.data.Length <= count)
            {
                T[] temp = new T[this.data.Length*2];
                Array.Copy(this.data,0, temp,0, count);
                //for (int i = 0; i < this.data.Length; i++)
                //{
                //    temp[i] = this.data[i];
                //}
                this.data = temp;
            }

            this.data[count] = data;
            count++;
            
        }

        public void Insert(int index, T data)
        {
            if (index<0||index>count)
            {
                throw new Exception("插入位置不正确");
            }
            if (this.data.Length <= count)
            {
                T[] temp = new T[this.data.Length * 2];
                Array.Copy(this.data, 0, temp, 0, count);
                this.data = temp;
            }
            if (index==count)
            {
                Add(data);
            }
            else
            {
                Array.Copy(this.data, index, this.data, index + 1, count - index);
                this.data[index] = data;
                count++;
            }

        }

        public void Remove(T data)
        {
            int index = GetIndexByValue(data);
            if (index!=-1)
            {
                RemoveAt(index);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>-1表示没有找到,否则返回对应下标</returns>
        int GetIndexByValue(T t)
        {
            for (int i = 0; i < count; i++)
            {
                //string 类型的==是用来比较内容的
                if (this.data[i].Equals(t))
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveAll(T data)
        {
            int index = GetIndexByValue(data);
            if (index!=-1)
            {
                RemoveAt(index);
                RemoveAll(data);
            }
            else
            {
                return;
            }
        }

        public void RemoveAt(int index)
        {
            if (index<0 || index>=count)
            {
                throw new Exception("删除的位置不正确");
            }
            Array.Copy(this.data, index + 1, this.data, index, count - index - 1);
            count--;
        }

        //列表转数组
        public T[] ToArray()
        {
            T[] temp = new T[count];
            Array.Copy(this.data, 0, temp, 0, count);
            return temp;
        }

        public override string ToString()
        {
            return "["+string.Join(",",ToArray())+"]";
        }

    }
}
