using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikoList
{
    class VicoList<T> where T: IComparable
    {
        private const int DefaultLength = 16;
        private T[] list;
        private int count;
        
        public VicoList(int count = 0) 
        {
            this.count = count;
            this.list = new T[DefaultLength];
        }
        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public void Add(T value)
        {
            if (count == list.Length)
            {
                Resize();
            }
            list[count] = value;
            count++;
        }

        private void Resize()
        {
            T[] newList = new T[count * 2];
            for (int i = 0; i < list.Length; i++)
            {
                newList[i] = list[i];
            }
            list = newList;
        }

        public void Remove(T value)
        {
            if (!list.Contains(value))
            {
                throw new AggregateException("Value is not in the array!");
            }
            for (int i = IndexOf(value); i < count - 1; i++)
            {
                list[i] = list[i + 1];
            }
            count--;
            list[count] = default(T);
            
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (value.Equals(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        //public T Min()
        //{
        //    T minValue = default (T);
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (minValue > (list[i])
        //        {
        //            list[i] = minValue;
        //        }
        //    }
        //    return minValue;
        //}

        public override string ToString()
        {
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("List is epty");
            }
            return string.Format(string.Join(", ", list.Take(count)));
        }
    }
}
