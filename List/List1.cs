using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class List1<T> : IEnumerable<T>
    {
        private const int defCapacity = 4;
        private T[] items;
        static readonly T[] emptyArray = new T[0];
        private int size;

        public List1()
        {
            items = emptyArray;
        }

        public int Count
        {
            get { return size; }
        }

        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value < size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (size > 0)
                        {
                            Array.Copy(items, 0, newItems, 0, size);
                        }

                        items = newItems;
                    }
                    else
                    {
                        items = emptyArray;
                    }
                }
            }
        }

        private void EnsureCapacity(int min) 
        {
            if (items.Length < min)
            {
                int newCapacity;
                if (items.Length == 0)
                {
                    newCapacity = defCapacity;
                }
                else 
                {
                    newCapacity = items.Length * 2;
                }
                if ((uint)newCapacity > Int32.MaxValue) newCapacity = Int32.MaxValue;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }


        public void Add(T item)
        {
            if (size == items.Length)
                EnsureCapacity(size + 1);
            items[size++] = item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new List1IEnumerator<T>(items, size);

        }
    }
}
