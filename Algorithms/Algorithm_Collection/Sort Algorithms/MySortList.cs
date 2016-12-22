using System;
using System.Collections.Generic;

namespace Algorithm_Collection.Sort_Algorithms
{
    public class MySortList<T> : List<T> where T : IComparable<T>
    {

        private bool sorted = false;
        private int combSortGap;
        private const double combSortShrink = 1.3;

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
                    SwapElements(position, position - 1);
                    position -= 1;
                }
            }
        }

        public void CombSort()
        {
            combSortGap = Count;
            while (!sorted)
            {
                // Update the combSortGap value for a next comb
                combSortGap = (int)Math.Floor(combSortGap / combSortShrink);
                if (combSortGap > 1)
                {
                    sorted = false; // We are never sorted as long as combSortGap > 1
                }
                else
                {
                    combSortGap = 1;
                    sorted = true; // If there are no swaps this pass, we are done
                }

                // A single "comb" over the input list
                int i = 0;
                while (i + combSortGap < Count)
                {   // See Shell sort for a similar idea
                    if (this[i].CompareTo(this[i + combSortGap]) > 0)
                    {
                        SwapElements(i, i + combSortGap);
                        sorted = false;
                    }
                    i++;
                }
            }
        }

        /// <summary>
        /// Run a SelectionSort Algorithm
        /// Complexity: O(n^2)
        /// /// </summary>
        public void SelectionSort()
        {
            int min = -1;
            for (int i = 0; i < Count - 1; i++)
            {
                min = i;
                for (int k = i + 1; k < Count; k++)
                {
                    if (this[min].CompareTo(this[k]) > 0)
                        min = k;
                }
                SwapElements(i, min);
            }
        }

        private void SwapElements(int i, int j)
        {
            T temp = this[j];
            this[j] = this[i];
            this[i] = temp;
        }

        public bool IsSorted()
        {
            for (int i = 1; i < Count; i++)
            {
                if (this[i - 1].CompareTo(this[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
