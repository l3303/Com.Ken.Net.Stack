using System;

namespace Com.Ken.NET.Stack.Util
{
    internal class Flag
    {
        /*private int page;
        public int Page { get { return page; } }*/

        private int length;

        public int Length
        {
            get { return length; }
        }

        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
        }

        private int lengthIndex;

        public int LengthIndex
        {
            get { return lengthIndex; }
        }

        public Flag(int length)
        {
            this.length = length;
            pageIndex = 0;
            lengthIndex = -1;
        }

        public static Flag operator +(Flag flag, int num)
        {
            if (flag != null)
            {
                if (flag.lengthIndex + num < flag.length)
                {
                    flag.lengthIndex += num;
                }
                else
                {
                    flag.pageIndex++;
                    flag.lengthIndex = num - (flag.length - flag.lengthIndex);
                }
                return flag;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static Flag operator ++(Flag flag)
        {
            return flag + 1;
        }

        public static Flag operator -(Flag flag, int num)
        {
            if (flag != null)
            {

                if (flag.lengthIndex - num > -1 || flag.pageIndex == 0 && flag.lengthIndex - num == -1)
                {
                    flag.lengthIndex -= num;
                }
                else
                {
                    if (flag.pageIndex > 0)
                    {
                        flag.pageIndex--;
                        flag.lengthIndex = flag.length - (num - flag.lengthIndex);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Flag cannot less than 0!");
                    }
                }
                return flag;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static int operator -(int num, Flag flag)
        {
            if (flag != null)
            {
                return num - flag.Count();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static int operator -(Flag f1, Flag f2)
        {
            if (f1 != null && f2 != null)
            {
                if (f1.length != f2.length)
                {
                    throw new ArgumentException("Flag with different page or length cannot substract!");
                }
                else
                {
                    return f1.Count() - f2.Count();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static Flag operator --(Flag flag)
        {
            return flag - 1;
        }

        public static bool operator >(Flag f1, Flag f2)
        {
            if (f1 != null && f2 != null)
            {
                if (f1.length != f2.length)
                {
                    throw new ArgumentException("Flag with different page or length cannot compare!");
                }
                else
                {
                    return f1.Count() > f2.Count();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static bool operator <(Flag f1, Flag f2)
        {
            return !(f1 > f2);
        }

        public override bool Equals(object obj)
        {
            Flag f = obj as Flag;
            if (f != null)
            {
                return this.Count() == f.Count();
            }
            return false;
        }

        public int Count()
        {
            return pageIndex*length + lengthIndex + 1;
        }

        public void SubstractPage()
        {
            pageIndex--;
            if (pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Page of Flag less than 0!");
            }
        }
    }
}
