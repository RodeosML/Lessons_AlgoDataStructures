using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass]
    public class BSTTests
    {
        private BST bst;

        [TestInitialize]
        public void Initialize()
        {
            bst = new BST();
        }

        [TestMethod]
        public void TestWideAllNodes_EmptyTree_ReturnsEmptyList()
        {
            bst.Root = null;

            List<BSTNode> wideList = bst.WideAllNodes();

            Assert.AreEqual(0, wideList.Count);
        }

        [TestMethod]
        public void TestWideAllNodes_SingleNode_ReturnsSingleNode()
        {
            int key = 5;
            object value = "Check";
            BSTNode node = new BSTNode(key, value, null);
            bst.Root = node;

            List<BSTNode> wideList = bst.WideAllNodes();

            Assert.AreEqual(1, wideList.Count);
            Assert.IsTrue(wideList.Contains(node));
        }

        [TestMethod]
        public void TestWideAllNodes_MultiLevelTree_ReturnsCorrectNodes()
        {
            int key1 = 5;
            object value1 = "Check";
            int key2 = 3;
            object value2 = "Check2";
            int key3 = 7;
            object value3 = "Check3";
            BSTNode node1 = new BSTNode(key1, value1, null);
            BSTNode node2 = new BSTNode(key2, value2, null);
            BSTNode node3 = new BSTNode(key3, value3, null);
            bst.Root = node1;
            node1.LeftChild = node2;
            node1.RightChild = node3;

            List<BSTNode> wideList = bst.WideAllNodes();

            Assert.AreEqual(3, wideList.Count);
            Assert.IsTrue(wideList.Contains(node1));
            Assert.IsTrue(wideList.Contains(node2));
            Assert.IsTrue(wideList.Contains(node3));
        }

        [TestMethod]
        public void TestDeepAllNodes_EmptyTree_ReturnsEmptyList()
        {
            bst.Root = null;

            List<BSTNode> deepList = bst.DeepAllNodes(0);

            Assert.AreEqual(0, deepList.Count);
        }

        [TestMethod]
        public void TestDeepAllNodes_SingleNode_ReturnsSingleNode()
        {
            int key = 5;
            object value = "Check1";
            BSTNode node = new BSTNode(key, value, null);
            bst.Root = node;

            List<BSTNode> deepList = bst.DeepAllNodes(0);

            Assert.AreEqual(1, deepList.Count);
            Assert.IsTrue(deepList.Contains(node));
        }

        [TestMethod]
        public void TestDeepAllNodes_MultiLevelTree_ReturnsCorrectNodes()
        {
            int key1 = 5;
            object value1 = "Check1";
            int key2 = 3;
            object value2 = "Check2";
            int key3 = 7;
            object value3 = "Check3";
            BSTNode node1 = new BSTNode(key1, value1, null);
            BSTNode node2 = new BSTNode(key2, value2, null);
            BSTNode node3 = new BSTNode(key3, value3, null);
            bst.Root = node1;
            node1.LeftChild = node2;
            node1.RightChild = node3;

            List<BSTNode> deepList = bst.DeepAllNodes(0);

            Assert.AreEqual(3, deepList.Count);
            Assert.IsTrue(deepList.Contains(node1));
            Assert.IsTrue(deepList.Contains(node2));
            Assert.IsTrue(deepList.Contains(node3));
        }
    }
}