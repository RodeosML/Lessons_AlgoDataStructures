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
        public void FindKeyIndex_EmptyTree_ReturnsZero()
        {
            // Arrange
            var aBST = new aBST(0);

            // Act
            int? result = aBST.FindKeyIndex(5);

            // Assert
            Assert.AreEqual(0, (int?)result);
        }

        [TestMethod]
        public void FindKeyIndex_KeyAtRoot_ReturnsZero()
        {
            // Arrange
            var aBST = new aBST(1);
            aBST.AddKey(3);

            // Act
            int? result = aBST.FindKeyIndex(3);

            // Assert
            Assert.AreEqual(0, (int?)result);
        }

        [TestMethod]
        public void FindKeyIndex_KeyAtLeftChild_ReturnsIndex()
        {
            // Arrange
            var aBST = new aBST(2);
            aBST.AddKey(1);
            aBST.AddKey(3);

            // Act
            int? result = aBST.FindKeyIndex(1);

            // Assert
            Assert.AreEqual(0, (int?)result);
        }

        [TestMethod]
        public void FindKeyIndex_KeyAtRightChild_ReturnsIndex()
        {
            // Arrange
            var aBST = new aBST(2);
            aBST.AddKey(1);
            aBST.AddKey(3);

            // Act
            int? result = aBST.FindKeyIndex(3);

            // Assert
            Assert.AreEqual(0, (int?)result);
        }
    }
}
