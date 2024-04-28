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
    }
}