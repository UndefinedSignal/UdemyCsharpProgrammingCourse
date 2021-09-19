using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] _items;
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
        }
        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyStack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if(_items.Length == Count)
            {
                T[] expandArray = new T[Count * 2];
                Array.Copy(_items, expandArray, Count);

                _items = expandArray;
            }
            _items[Count++] = item; // Inc Count after add a object;
        }

        public void Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = default; 
        }

        public object Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count - 1];
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new StackEnumerator<T>(_items, Count);
        //}

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private readonly int count;
        private int position;

        public StackEnumerator(T[] array, int count)
        {
            this.array = array;
            this.count = count;

            position = count;
        }
        public T Current => array[position];

        object IEnumerator.Current => array[position];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position--;
            return position >= 0;
        }

        public void Reset()
        {
            position = count;
        }
    }
}
