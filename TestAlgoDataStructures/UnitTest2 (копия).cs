using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass]
    public class BSTTests2
    {

        [TestMethod]
        public void WideAllNodesReturnsCorrectList()
        {
            var rootNode = new BSTNode<int>(5, 5, null);
            rootNode.LeftChild = new BSTNode<int>(3, 3, rootNode);
            rootNode.RightChild = new BSTNode<int>(8, 8, rootNode);
            rootNode.LeftChild.LeftChild = new BSTNode<int>(2, 2, rootNode.LeftChild);
            rootNode.LeftChild.RightChild = new BSTNode<int>(4, 4, rootNode.LeftChild);
            rootNode.RightChild.LeftChild = new BSTNode<int>(7, 7, rootNode.RightChild);
            rootNode.RightChild.RightChild = new BSTNode<int>(9, 9, rootNode.RightChild);

            var bst = new BST<int>(rootNode);

            var wideList = bst.WideAllNodes();

            var expectedKeys = new int[] { 5, 3, 8, 2, 4, 7, 9 };
            for (int i = 0; i < wideList.Count; i++)
            {
                Assert.AreEqual(expectedKeys[i], wideList[i].NodeKey);
            }
        }

        [TestMethod]
        public void DeepAllNodesInOrderReturnsCorrectList()
        {
            var rootNode = new BSTNode<int>(5, 5, null);
            rootNode.LeftChild = new BSTNode<int>(3, 3, rootNode);
            rootNode.RightChild = new BSTNode<int>(8, 8, rootNode);
            rootNode.LeftChild.LeftChild = new BSTNode<int>(2, 2, rootNode.LeftChild);
            rootNode.LeftChild.RightChild = new BSTNode<int>(4, 4, rootNode.LeftChild);
            rootNode.RightChild.LeftChild = new BSTNode<int>(7, 7, rootNode.RightChild);
            rootNode.RightChild.RightChild = new BSTNode<int>(9, 9, rootNode.RightChild);

            var bst = new BST<int>(rootNode);

            var deepList = bst.DeepAllNodes(0);

            var expectedKeys = new int[] { 2, 3, 4, 5, 7, 8, 9 };
            for (int i = 0; i < deepList.Count; i++)
            {
                Assert.AreEqual(expectedKeys[i], deepList[i].NodeKey);
            }
        }

        [TestMethod]
        public void DeepAllNodesPostOrderReturnsCorrectList()
        {
            var rootNode = new BSTNode<int>(5, 5, null);
            rootNode.LeftChild = new BSTNode<int>(3, 3, rootNode);
            rootNode.RightChild = new BSTNode<int>(8, 8, rootNode);
            rootNode.LeftChild.LeftChild = new BSTNode<int>(2, 2, rootNode.LeftChild);
            rootNode.LeftChild.RightChild = new BSTNode<int>(4, 4, rootNode.LeftChild);
            rootNode.RightChild.LeftChild = new BSTNode<int>(7, 7, rootNode.RightChild);
            rootNode.RightChild.RightChild = new BSTNode<int>(9, 9, rootNode.RightChild);

            var bst = new BST<int>(rootNode);

            var deepList = bst.DeepAllNodes(1);

            var expectedKeys = new int[] { 2, 4, 3, 7, 9, 8, 5 };
            for (int i = 0; i < deepList.Count; i++)
            {
                Assert.AreEqual(expectedKeys[i], deepList[i].NodeKey);
            }
        }

        [TestMethod]
        public void DeepAllNodesPreOrderReturnsCorrectList()
        {
            var rootNode = new BSTNode<int>(5, 5, null);
            rootNode.LeftChild = new BSTNode<int>(3, 3, rootNode);
            rootNode.RightChild = new BSTNode<int>(8, 8, rootNode);
            rootNode.LeftChild.LeftChild = new BSTNode<int>(2, 2, rootNode.LeftChild);
            rootNode.LeftChild.RightChild = new BSTNode<int>(4, 4, rootNode.LeftChild);
            rootNode.RightChild.LeftChild = new BSTNode<int>(7, 7, rootNode.RightChild);
            rootNode.RightChild.RightChild = new BSTNode<int>(9, 9, rootNode.RightChild);

            var bst = new BST<int>(rootNode);

            var deepList = bst.DeepAllNodes(2);

            var expectedKeys = new int[] { 5, 3, 2, 4, 8, 7, 9 };
            for (int i = 0; i < deepList.Count; i++)
            {
                Assert.AreEqual(expectedKeys[i], deepList[i].NodeKey);
            }
        }

    }
}