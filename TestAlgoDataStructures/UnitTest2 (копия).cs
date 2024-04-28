using AlgorithmsDataStructures2;
using System;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass]
    public class BSTTests2
    {
        BST<int> tree;
        BST<int> emptyTree;
        BSTNode<int> root;

        [TestInitialize]
        public void TestInitialize()
        {
            root = new BSTNode<int>(0, 0, null);
            tree = new BST<int>(root);
            emptyTree = new BST<int>(null);
        }

        [TestMethod]
        public void DeepTestWithOption0()
        {
            DeepTest(0);
        }

        [TestMethod]
        public void DeepTestWithOption1()
        {
            DeepTest(1);
        }

        [TestMethod]
        public void DeepTestWithOption2()
        {
            DeepTest(2);
        }

        private void DeepTest(int option)
        {
            Assert.AreEqual(0, emptyTree.DeepAllNodes(option).Count);

            emptyTree.AddKeyValue(5, 5);

            for (int i = 0; i < 5; ++i)
            {
                emptyTree.AddKeyValue(i, i);
            }

            for (int i = 6; i < 10; ++i)
            {
                emptyTree.AddKeyValue(i, i);
            }

            Assert.AreEqual(10, emptyTree.DeepAllNodes(option).Count);
        }

        [TestMethod]
        public void WideTest()
        {
            Assert.AreEqual(0, emptyTree.WideAllNodes().Count);

            emptyTree.AddKeyValue(5, 5);
            for (int i = 0; i < 5; ++i)
            {
                emptyTree.AddKeyValue(i, i);
            }

            for (int i = 6; i < 10; ++i)
            {
                emptyTree.AddKeyValue(i, i);
            }

            Assert.AreEqual(10, emptyTree.WideAllNodes().Count);
        }

        [TestMethod]
        public void InOrderIsCorrect()
        {
            var bst = new BST<int>(null);

            bst.AddKeyValue(10, 10);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(15, 15);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(7, 7);

            List<BSTNode> result = bst.DeepAllNodes(1);

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(3, result[0].NodeKey);
            Assert.AreEqual(5, result[1].NodeKey);
            Assert.AreEqual(7, result[2].NodeKey);
            Assert.AreEqual(10, result[3].NodeKey);
            Assert.AreEqual(15, result[4].NodeKey);
        }

        [TestMethod]
        public void PreOrderIsCorrect()
        {
            var bst = new BST<int>(null);

            bst.AddKeyValue(10, 10);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(15, 15);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(7, 7);

            List<BSTNode> result = bst.DeepAllNodes(0);

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(10, result[0].NodeKey);
            Assert.AreEqual(5, result[1].NodeKey);
            Assert.AreEqual(3, result[2].NodeKey);
            Assert.AreEqual(7, result[3].NodeKey);
            Assert.AreEqual(15, result[4].NodeKey);
        }

        [TestMethod]
        public void PostOrderIsCorrect()
        {
            var bst = new BST<int>(null);

            bst.AddKeyValue(10, 10);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(15, 15);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(7, 7);

            List<BSTNode> result = bst.DeepAllNodes(2);

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(3, result[0].NodeKey);
            Assert.AreEqual(7, result[1].NodeKey);
            Assert.AreEqual(5, result[2].NodeKey);
            Assert.AreEqual(15, result[3].NodeKey);
            Assert.AreEqual(10, result[4].NodeKey);
        }
    }
}