using System;
using Com.Ken.NET.Stack.Interface;
using Com.Ken.NET.Stack.UserException;
using Com.Ken.NET.Stack.Util;

namespace Com.Ken.NET.Stack
{
    class AutoStack<T> : IStack<T>
    {
        private static int MAX_COUNT = 10000000;

        private int pageLength = 100;
        private T[][] stack;

        private Flag flag;

        public AutoStack()
        {
            int page = MAX_COUNT/pageLength;
            if (MAX_COUNT % pageLength != 0)
            {
                page++;
            }
            stack = new T[page][];
            stack[0] = new T[page];
            flag = new Flag(pageLength);
        }

        public void Push(T obj)
        {
            int prePage = flag.PageIndex;
            flag++;
            if (flag.Count() > MAX_COUNT)
            {
                throw new FullStackException(MAX_COUNT);
            }

            if (flag.PageIndex != prePage)
            {
                stack[flag.PageIndex] = new T[pageLength];
            }
            stack[flag.PageIndex][flag.LengthIndex] = obj;
        }

        public T Pop()
        {
            if (flag.Count() > 0)
            {
                var returnValue = stack[flag.PageIndex][flag.LengthIndex];
                int prePage = flag.PageIndex;
                flag--;
                if (prePage != flag.PageIndex)
                {
                    stack[prePage] = null;
                }
                return returnValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException(this.GetType().Name, "Cannot pop empty stack!");
            }
        }

        public bool IsFull()
        {
            return flag.Count() >= MAX_COUNT;
        }

        public int Length()
        {
            return flag.Count();
        }
    }
}
