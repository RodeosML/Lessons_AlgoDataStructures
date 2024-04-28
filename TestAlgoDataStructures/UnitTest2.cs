using AlgorithmsDataStructures1;
using System;

namespace AlgorithmsDataStructures1.Tests
{
    [TestClass]
    public class BSTTests
    {
        BST<int> Tree;
        BST<int> ZeroTree;

        [TestInitialize]
        public void TestInitialize()
        {
            ZeroTree = new BST<int>(null);
            Tree = new BST<int>(null);

            Tree.AddKeyValue(60, 60);
            Tree.AddKeyValue(120, 120);
            Tree.AddKeyValue(30, 30);
            Tree.AddKeyValue(180, 180);
            Tree.AddKeyValue(15, 15);
            Tree.AddKeyValue(45, 45);
            Tree.AddKeyValue(100, 100);
            Tree.AddKeyValue(90, 90);
            Tree.AddKeyValue(95, 95);
        }

        [TestMethod]
        public void AddKeyValue()
        {
            Assert.AreEqual(0, ZeroTree.Count());
            ZeroTree.AddKeyValue(180, 180);
            ZeroTree.AddKeyValue(15, 15);
            ZeroTree.AddKeyValue(45, 45);
            Assert.AreEqual(3, ZeroTree.Count());

            Assert.AreEqual(9, Tree.Count());
            Tree.AddKeyValue(180, 180);
            Tree.AddKeyValue(15, 15);
            Tree.AddKeyValue(45, 45);
            Assert.AreEqual(9, Tree.Count());

            Assert.AreEqual(false, Tree.FindNodeByKey(-60).NodeHasKey);
            Assert.AreEqual(false, Tree.FindNodeByKey(35).NodeHasKey);
            Assert.AreEqual(false, Tree.FindNodeByKey(200).NodeHasKey);

            Tree.AddKeyValue(-60, -60);
            Tree.AddKeyValue(35, 35);
            Tree.AddKeyValue(200, 200);
            Assert.AreEqual(12, Tree.Count());

            Assert.AreEqual(true, Tree.FindNodeByKey(-60).NodeHasKey);
            Assert.AreEqual(true, Tree.FindNodeByKey(35).NodeHasKey);
            Assert.AreEqual(true, Tree.FindNodeByKey(200).NodeHasKey);
        }


        [TestMethod]
        public void FindNodeByKey()
        {
            Assert.AreEqual(null, ZeroTree.FindNodeByKey(25).Node);

            Assert.AreEqual(true, Tree.FindNodeByKey(13).ToLeft);
            Assert.AreEqual(false, Tree.FindNodeByKey(13).NodeHasKey);
            Assert.AreEqual(15, Tree.FindNodeByKey(13).Node.NodeKey);

            Assert.AreEqual(false, Tree.FindNodeByKey(250).ToLeft);
            Assert.AreEqual(false, Tree.FindNodeByKey(250).NodeHasKey);
            Assert.AreEqual(180, Tree.FindNodeByKey(250).Node.NodeKey);

            Assert.AreEqual(false, Tree.FindNodeByKey(100).ToLeft);
            Assert.AreEqual(true, Tree.FindNodeByKey(100).NodeHasKey);
            Assert.AreEqual(100, Tree.FindNodeByKey(100).Node.NodeKey);
            Assert.AreEqual(120, Tree.FindNodeByKey(100).Node.Parent.NodeKey);
            Assert.AreEqual(90, Tree.FindNodeByKey(100).Node.LeftChild.NodeKey);
            Assert.AreEqual(null, Tree.FindNodeByKey(100).Node.RightChild);
        }

        [TestMethod]
        public void DeleteNodeByKeyTestOnlyLeft()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node2 = new BSTNode<int>(2, 2, node4);
            node4.LeftChild = node2;
            BSTNode<int> node1 = new BSTNode<int>(1, 1, node2);
            BSTNode<int> node3 = new BSTNode<int>(3, 3, node2);
            node2.LeftChild = node1;
            node2.RightChild = node3;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            bool result = tree.DeleteNodeByKey(4);

            Assert.IsTrue(result);
            Assert.IsFalse(tree.FindNodeByKey(4).NodeHasKey);
            Assert.AreEqual(2, tree.FindNodeByKey(8).Node.LeftChild.NodeKey);
            Assert.AreEqual(1, tree.FindNodeByKey(8).Node.LeftChild.LeftChild.NodeKey);
            Assert.AreEqual(3, tree.FindNodeByKey(8).Node.LeftChild.RightChild.NodeKey);
            Assert.AreEqual(7, tree.Count());
        }

        [TestMethod]
        public void DeleteNodeByKeyTestOnlyRight()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node6 = new BSTNode<int>(6, 6, node4);
            node4.RightChild = node6;
            BSTNode<int> node5 = new BSTNode<int>(5, 5, node6);
            BSTNode<int> node7 = new BSTNode<int>(7, 7, node6);
            node6.LeftChild = node5;
            node6.RightChild = node7;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            bool result = tree.DeleteNodeByKey(4);

            Assert.IsTrue(result);
            Assert.IsFalse(tree.FindNodeByKey(4).NodeHasKey);
            Assert.AreEqual(5, tree.FindNodeByKey(8).Node.LeftChild.NodeKey);
            Assert.AreEqual(6, tree.FindNodeByKey(8).Node.LeftChild.RightChild.NodeKey);
            Assert.AreEqual(7, tree.FindNodeByKey(8).Node.LeftChild.RightChild.RightChild.NodeKey);
            Assert.IsNull(tree.FindNodeByKey(8).Node.LeftChild.RightChild.LeftChild);
            Assert.AreEqual(7, tree.Count());
        }

        [TestMethod]
        public void DeleteNodeByKeyTestLast()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BST<int> tree = new BST<int>(node8);

            bool result = tree.DeleteNodeByKey(8);

            Assert.IsTrue(result);
            Assert.IsFalse(tree.FindNodeByKey(8).NodeHasKey);
            Assert.AreEqual(0, tree.Count());
        }

        [TestMethod]
        public void FindNodeByKeyTest()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node2 = new BSTNode<int>(2, 2, node4);
            BSTNode<int> node6 = new BSTNode<int>(6, 6, node4);
            node4.LeftChild = node2;
            node4.RightChild = node6;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            BSTFind<int> foundNode1 = tree.FindNodeByKey(2);
            BSTFind<int> foundNode2 = tree.FindNodeByKey(1);
            BSTFind<int> foundNode3 = tree.FindNodeByKey(7);

            Assert.AreEqual(2, foundNode1.Node.NodeKey);
            Assert.IsTrue(foundNode1.NodeHasKey);

            Assert.AreEqual(2, foundNode2.Node.NodeKey);
            Assert.IsFalse(foundNode2.NodeHasKey);
            Assert.IsTrue(foundNode2.ToLeft);

            Assert.AreEqual(6, foundNode3.Node.NodeKey);
            Assert.IsFalse(foundNode3.NodeHasKey);
            Assert.IsFalse(foundNode3.ToLeft);
        }

        [TestMethod]
        public void FinMinMaxTestStartFromRootFindMax()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node2 = new BSTNode<int>(2, 2, node4);
            BSTNode<int> node6 = new BSTNode<int>(6, 6, node4);
            node4.LeftChild = node2;
            node4.RightChild = node6;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            BSTNode<int> maxNode = tree.FinMinMax(node8, true);

            Assert.AreEqual(14, maxNode.NodeKey);
        }

        [TestMethod]
        public void FinMinMaxTestStartFromRootFindMin()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node2 = new BSTNode<int>(2, 2, node4);
            BSTNode<int> node6 = new BSTNode<int>(6, 6, node4);
            node4.LeftChild = node2;
            node4.RightChild = node6;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            BSTNode<int> minNode = tree.FinMinMax(node8, false);

            Assert.AreEqual(2, minNode.NodeKey);
        }

        [TestMethod]
        public void FinMinMaxTestStartFromSubtreeFindMax()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node2 = new BSTNode<int>(2, 2, node4);
            BSTNode<int> node6 = new BSTNode<int>(6, 6, node4);
            node4.LeftChild = node2;
            node4.RightChild = node6;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            BSTNode<int> maxNode = tree.FinMinMax(node4, true);

            Assert.AreEqual(6, maxNode.NodeKey);
        }

        [TestMethod]
        public void FinMinMaxTestStartFromSubtreeFindMin()
        {
            BSTNode<int> node8 = new BSTNode<int>(8, 8, null);
            BSTNode<int> node4 = new BSTNode<int>(4, 4, node8);
            BSTNode<int> node12 = new BSTNode<int>(12, 12, node8);
            node8.LeftChild = node4;
            node8.RightChild = node12;
            BSTNode<int> node2 = new BSTNode<int>(2, 2, node4);
            BSTNode<int> node6 = new BSTNode<int>(6, 6, node4);
            node4.LeftChild = node2;
            node4.RightChild = node6;
            BSTNode<int> node10 = new BSTNode<int>(10, 10, node12);
            BSTNode<int> node14 = new BSTNode<int>(14, 14, node12);
            node12.LeftChild = node10;
            node12.RightChild = node14;

            BST<int> tree = new BST<int>(node8);

            BSTNode<int> minNode = tree.FinMinMax(node12, false);

            Assert.AreEqual(10, minNode.NodeKey);
        }

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