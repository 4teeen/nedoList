using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    class List1IEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _items;
        private int _index = -1;
        private int _size;

        public List1IEnumerator(T[] items, int size)
        {
            _items = items;
            _size = size;
        }


        public bool MoveNext()
        {
            return ++_index < _size;
        }

        public void Reset()
        {
            _index = -1;
        }

        public T Current => _items[_index];

        object IEnumerator.Current => Current;
        public void Dispose()
        {
        }
    }
}
