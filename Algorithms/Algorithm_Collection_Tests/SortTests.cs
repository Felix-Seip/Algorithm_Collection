using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm_Collection.Sort_Algorithms;

namespace Algorithm_Collection_Tests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void StupidSortTest()
        {
            MySortList<int> mList = new MySortList<int>();
            mList.Add(5);
            mList.Add(1);
            mList.Add(12);
            mList.Add(40);
            mList.Add(2);

            mList.StupidSort();
            Assert.IsTrue(mList.IsSorted());
        }
    }
}
