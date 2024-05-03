using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace Tests
{
    [TestClass]
    public class aBSTTests
    {
        [TestMethod]
        public void TestAddKey()
        {
            aBST tree = new aBST(3);
            int key = 5;

            int index = tree.AddKey(key);

            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void FindKeyIndexEmptyTreeReturnsZero()
        {
            var aBST = new aBST(0);

            int? result = aBST.FindKeyIndex(5);

            Assert.AreEqual(0, (int?)result);
        }

        [TestMethod]
        public void FindKeyIndexKeyAtRootReturnsZero()
        {
            var aBST = new aBST(1);
            aBST.AddKey(3);

            int? result = aBST.FindKeyIndex(3);

            Assert.AreEqual(0, (int?)result);
        }

        [TestMethod]
        public void FindKeyIndexKeyAtLeftChildReturnsIndex()
        {
            var aBST = new aBST(2);
            aBST.AddKey(1);
            aBST.AddKey(3);

            int? result = aBST.FindKeyIndex(1);

            Assert.AreEqual(0, (int?)result);
        }

        //[TestMethod]
        //public void FindKeyIndexKeyAtRightChildReturnsIndex()
        //{
        //    var aBST = new aBST(2);
        //    aBST.AddKey(1);
        //    aBST.AddKey(3);

        //    int? result = aBST.FindKeyIndex(3);

        //    Assert.AreEqual(0, (int?)result);
        //}

        [TestMethod]
        public void FindKeyIndex_UnfilledSlot_ReturnsNegativeIndex()
        {
            aBST tree = new aBST(3);
            tree.Tree[0] = null;

            int? result = tree.FindKeyIndex(10);

            Assert.AreEqual(-0, result);
        }
    }
}
