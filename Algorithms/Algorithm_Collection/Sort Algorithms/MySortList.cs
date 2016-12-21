using System;
using System.Collections.Generic;

namespace Algorithm_Collection.Sort_Algorithms
{
    public class MySortList<T> : List<T> where T : IComparable<T>
    {
        public void StupidSort()
        {
            int position = 0;
            while (position < Count)
            {
                if (position == 0 || this[position].CompareTo(this[position - 1]) >= 0)
                {
                    position += 1;
                }
                else
                {
                    T temp = this[position - 1];
                    this[position - 1] = this[position];
                    this[position] = temp;
                    position -= 1;
                }
            }
        }

        public bool IsSorted()
        {
            for(int i = 1; i < Count; i++)
            {
                if(this[i-1].CompareTo(this[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
