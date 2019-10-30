using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dic
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDicitonary<int,string> dic = new MyDicitonary<int, string>();
            dic.Add(1001, "1001");
            dic.Add(1002, "1002");
            dic.Add(1003, "1003");
            dic.Remove(1002);
            dic[1001] = "哦豁";

            Console.WriteLine(dic[1001]);

        }
    }

    interface IDicitonary<Key, Value>
    {
        //增
        void Add(Key key,Value value);

        //删
        void Remove(Key key);

        Value this[Key key]
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

    class KeyValuePairs<TKey, TValue>
    {
        TKey key;
        TValue value;

        public TKey Key { get => key; set => key = value; }
        public TValue Value { get => value; set => this.value = value; }

        public KeyValuePairs()
        {
            key = default(TKey);
            value = default(TValue);
        }

        public KeyValuePairs(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }
    class Dicitionary<Key,Value> : IDicitonary<Key, Value>
    {
        /*Key[] keys;
        Value[] values;
        int count;
        public Dicitionary()
        {
            keys = new Key[4];
            values = new Value[4];
            count = 0;
        }

        public Value this[Key key]
        {
            get
            {
                int index = GetIndexByKey(key);
                if (index == -1)
                {
                    throw new Exception("不包含这个键");
                }
                return values[index];

            }
            set
            {
                int index = GetIndexByKey(key);
               
                //存在这个键
                if (index != -1)
                {
                    values[index] = value;
                }

                //不存在这个键
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
            for (int i = 0; i < count; i++)
            {
                if (keys[i].Equals(key))
                {
                    return i;
                }
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
                throw new Exception("当前容器已经包含这个键");
            }
            if (count>=keys.Length)
            {
                Key[] newKeys = new Key[keys.Length * 2];
                Value[] newValues = new Value[values.Length * 2];
                Array.Copy(keys, 0, newKeys, 0, keys.Length);
                Array.Copy(values, 0, newValues, 0, values.Length);
                keys = newKeys;
                values = newValues;
            }
            keys[count] = key;
            values[count] = value;
            count++;
        }

        public void Remove(Key key)
        {
            int index = GetIndexByKey(key);
            if (index!=-1)
            {
                Array.Copy(keys, index + 1, keys, index, count - index - 1);
                Array.Copy(values, index + 1, values, index, count - index - 1);
            }
        }*/

        #region 用一个数组封装的方式
        KeyValuePairs<Key, Value>[] pairs;
        int count;

        public Dicitionary()
        {
            pairs = new KeyValuePairs<Key, Value>[4];
            count = 0;
        }

        int GetIndexByKey(Key key)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (pairs[i].Key.Equals(key))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public bool ContainsKey(Key key)
        {
            return GetIndexByKey(key) != -1;
        }

        public void Add(Key key, Value value)
        {
            if (ContainsKey(key))
            {
                throw new Exception("当前容器中拥有这个键，无法进行增加操作");
            }
            if (count >= pairs.Length)
            {
                KeyValuePairs<Key, Value>[] newPairs = new KeyValuePairs<Key, Value>[pairs.Length * 2];
                Array.Copy(pairs, 0, newPairs, 0, pairs.Length);
                pairs = newPairs;
            }
            pairs[count] = new KeyValuePairs<Key, Value>(key, value);
            count++;
        }

        public void Remove(Key key)
        {
            int index = GetIndexByKey(key);
            if (index != -1)
            {
                Array.Copy(pairs, index + 1, pairs, index, count - index - 1);
                count--;
            }
        }

        public Value this[Key key]
        {
            get
            {
                int index = GetIndexByKey(key);
                if (index != -1)
                {
                    return pairs[index].Value;
                }
                else
                {
                    throw new Exception("当前容器中没有这个键，无法得到对应的值");
                }
            }
            set
            {
                int index = GetIndexByKey(key);
                if (index != -1)
                {
                    pairs[index].Value = value;
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
        #endregion

    }
}
