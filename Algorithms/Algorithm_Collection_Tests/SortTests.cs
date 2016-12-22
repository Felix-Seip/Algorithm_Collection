using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm_Collection.Sort_Algorithms;

namespace Algorithm_Collection_Tests
{
    [TestClass]
    public class SortTests
    {
        private const int cListCount = 100;
        private Random random;
        MySortList<int> intList = new MySortList<int>();

        [TestInitialize]
        public void initTest()
        {
            random = new Random();
            for(int i = 0; i < cListCount; i++)
            {
                intList.Add(random.Next(cListCount));
            }
        }
        [TestMethod]
        public void StupidSortTest()
        {
            intList.StupidSort();
            Assert.IsTrue(intList.IsSorted());
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            intList.InsertionSort();
            Assert.IsTrue(intList.IsSorted());
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            intList.BubbleSort();
            Assert.IsTrue(intList.IsSorted());
        }

        [TestMethod]
        public void SelectionSortTest()
        {
            intList.SelectionSort();
            Assert.IsTrue(intList.IsSorted());
        }

        [TestMethod]
        public void CombSortTest()
        {
            intList.CombSort();
            Assert.IsTrue(intList.IsSorted());
        }
    }
}
