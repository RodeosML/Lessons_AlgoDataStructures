using AlgorithmsDataStructures2;

namespace BalancedBSTTests
{
    [TestClass]
    public class BalancedBSTTests
    {
        [TestMethod]
        public void TestGenerateTree()
        {
            var bst = new BalancedBST();
            int[] inputArray = { 4, 2, 6, 1, 3, 5, 7 };

            bst.GenerateTree(inputArray);

            Assert.IsNotNull(bst.Root);
            Assert.AreEqual(4, bst.Root.NodeKey);
            Assert.AreEqual(2, bst.Root.LeftChild.NodeKey);
            Assert.AreEqual(6, bst.Root.RightChild.NodeKey);
            Assert.AreEqual(1, bst.Root.LeftChild.LeftChild.NodeKey);
            Assert.AreEqual(3, bst.Root.LeftChild.RightChild.NodeKey);
            Assert.AreEqual(5, bst.Root.RightChild.LeftChild.NodeKey);
            Assert.AreEqual(7, bst.Root.RightChild.RightChild.NodeKey);
        }

        [TestMethod]
        public void TestIsBalanced()
        {
            var bst = new BalancedBST();
            int[] inputArray = { 4, 2, 6, 1, 3, 5, 7 };
            bst.GenerateTree(inputArray);

            bool balanced = bst.IsBalanced(bst.Root);

            Assert.IsTrue(balanced);
        }

        [TestMethod]
        public void TestIsNotBalanced()
        {
            var bst = new BalancedBST();
            int[] inputArray = { 4, 2, 1, 3 };
            bst.GenerateTree(inputArray);

            bool balanced = bst.IsBalanced(bst.Root);

            Assert.IsFalse(balanced);
        }
    }
}
