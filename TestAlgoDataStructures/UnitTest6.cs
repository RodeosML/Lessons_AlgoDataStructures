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

        [TestMethod]
        public void TestNodeLevelsStartFromZero()
        {
            int[] testData = { 5, 3, 8, 2, 4, 7, 9 };

            BalancedBST bst = new BalancedBST();
            bst.GenerateTree(testData);

            Assert.IsTrue(CheckNodeLevels(bst.Root));
        }

        private bool CheckNodeLevels(BSTNode node)
        {
            if (node == null) return true;

            if (node.Level < 0) return false; //Уровень не может быть отрицательным

            if (node.Parent == null && node.Level != 0) return false; //Для корня уровень должен быть 0

            if (node.Parent != null && node.Level != node.Parent.Level + 1) return false; //Уровень дочерних узлов должен увеличиваться на 1

            return CheckNodeLevels(node.LeftChild) && CheckNodeLevels(node.RightChild);
        }
    }
}
