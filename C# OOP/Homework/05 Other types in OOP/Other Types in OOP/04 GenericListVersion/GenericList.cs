using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GenericListVersion
{
    [Version(0, 1)]
    class GenericList<T> where T : IComparable<T>
    {
        private const int Capacity = 16;
        private T[] elements;
        private int elementsCount = 0;

        public GenericList()
        {
            this.elements = new T[Capacity];
        }

        public T this[int i]
        {
            get { return elements[i]; }
            set { elements[i] = value; }
        }

        public void Add(T elementToAdd)
        {
            if (this.elements.Length == this.elementsCount)
            {
                ResizeArray();
            }

            this.elements[this.elementsCount] = elementToAdd;
            this.elementsCount++;
        }

        private void ResizeArray()
        {
            T[] newList = new T[elementsCount * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                newList[i] = elements[i];
            }
            elements = newList;
        }

        public void Remove(int elementIndex)
        {
            if (elementIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index is not in the range of the Generic list!");
            }
            else if (elementIndex > this.elementsCount - 1)
            {
                return;
            }

            for (int i = elementIndex; i < this.elementsCount - 1; i++)
            {
                this.elements[i] = elements[i + 1];
            }

            this.elements[this.elementsCount - 1] = default(T);
            this.elementsCount--;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= this.elementsCount)
            {
                throw new ArgumentOutOfRangeException("Index is not in the range of the Generic list!");
            }
            while (this.elementsCount + 1 >= this.elements.Length)
            {
                ResizeArray();
            }
            for (int i = this.elements.Length - 1; i >= index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
            this.elements[index] = element;
            this.elementsCount++;
        }

        public void Clear()
        {
            this.elements = new T[Capacity];
            elementsCount = 0;
        }

        public int FindElementIndex(T element)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                if (element.Equals(this.elements[i]))
                {
                    return i;
                }

            }
            return -1;
        }

        public bool Contains(T value)
        {
            return this.elements.Contains(value);
        }

        public T Min()
        {
            return this.elements.Min();
        }

        public T Max()
        {
            return this.elements.Max();
        }

        public override string ToString()
        {
            if (elementsCount == 0)
            {
                throw new AggregateException("List is empty!");
            }
            return string.Format(string.Join(", ", this.elements.Take(elementsCount)));
        }
        

        public void Version()
        {
            Type type = typeof(GenericList<T>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var attribute in allAttributes)
            {
                if (attribute is Version)
                {
                    Version temp = attribute as Version;
                    Console.WriteLine("GenericList v.{0}.{1}", temp.Major, temp.Minor);
                }
            }
        }
        
    }
}
