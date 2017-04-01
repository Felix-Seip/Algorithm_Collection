using System;

namespace Algorithm_Collection.Encryption
{
    public class RandomGenerator
    {
        private long currentX;
        private int A;
        private int M;
        public RandomGenerator(int startValue, int a, int m)
        {
            currentX = startValue;
            A = a;
            M = m;
        }

        public long GenerateNextNumber(long maxValue)
        {
            long number = ((16807l * currentX)) % maxValue;
            currentX = number;
            return number;
        }
    }
}
