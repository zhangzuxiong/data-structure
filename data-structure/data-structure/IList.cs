using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{

    //泛型：用一种类型泛指其他类型的做法叫做泛型
    interface IArrayList<T>
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

}
