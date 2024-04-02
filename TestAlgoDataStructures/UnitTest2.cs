using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass]
    public class BSTTests
    {
        [TestMethod]
        public void AddKeyValue_WhenKeyIsAbsent_AddsNodeCorrectly()
        {
            BST<int> bst = new BST<int>(null);

            bool addedLeft = bst.AddKeyValue(5, 5);
            bool addedRight = bst.AddKeyValue(8, 8);

            Assert.IsTrue(addedLeft);
            Assert.IsTrue(addedRight);
            Assert.IsTrue(bst.FindNodeByKey(5).NodeHasKey);
            Assert.IsTrue(bst.FindNodeByKey(8).NodeHasKey);
        }

        [TestMethod]
        public void AddKeyValue_WhenKeyIsPresent_DoesNotAddNode()
        {
            
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);

            
            bool added = bst.AddKeyValue(5, 5);

            Assert.IsFalse(added);
            Assert.IsTrue(bst.FindNodeByKey(5).NodeHasKey);
        }

        [TestMethod]
        public void FindNodeByKey_WhenKeyIsAbsent_ReturnsCorrectInfo()
        {
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);

            BSTFind<int> resultLeft = bst.FindNodeByKey(2);
            BSTFind<int> resultRight = bst.FindNodeByKey(7);

            Assert.IsFalse(resultLeft.NodeHasKey);
            Assert.IsTrue(resultLeft.ToLeft);
            Assert.IsFalse(resultRight.NodeHasKey);
            Assert.IsFalse(resultRight.ToLeft);
        }


        [TestMethod]
        public void FindNodeByKey_WhenKeyIsPresent_ReturnsCorrectInfo()
        {
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);

            BSTFind<int> result = bst.FindNodeByKey(3);

            Assert.IsTrue(result.NodeHasKey);
            Assert.AreEqual(3, result.Node.NodeKey);
        }

        [TestMethod]
        public void FindNodeByKey_test()
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

            BSTFind<int> foundNode = tree.FindNodeByKey(2);
            Assert.AreEqual(2, foundNode.Node.NodeKey);
            Assert.IsTrue(foundNode.NodeHasKey);

            foundNode = tree.FindNodeByKey(1);
            Assert.AreEqual(2, foundNode.Node.NodeKey);
            Assert.IsFalse(foundNode.NodeHasKey);
            Assert.IsTrue(foundNode.ToLeft);

            foundNode = tree.FindNodeByKey(7);
            Assert.AreEqual(6, foundNode.Node.NodeKey);
            Assert.IsFalse(foundNode.NodeHasKey);
            Assert.IsFalse(foundNode.ToLeft);
        }

        [TestMethod]
        public void TestDeleteNodeByKey_Success()
        {
            
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);
            bst.AddKeyValue(2, 2);
            bst.AddKeyValue(4, 4);
            bst.AddKeyValue(7, 7);
            bst.AddKeyValue(9, 9);

            
            bool result = bst.DeleteNodeByKey(3);

            
            Assert.IsTrue(result);
            Assert.IsNull(bst.FindNodeByKey(3).Node);
            Assert.IsFalse(bst.FindNodeByKey(5).Node.LeftChild.NodeKey == 3);
        }

        [TestMethod]
        public void TestDeleteNodeByKey_DeleteNodeWithoutChildren()
        {
            
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);

            
            bool result = bst.DeleteNodeByKey(8);

            
            Assert.IsTrue(result);
            Assert.IsNull(bst.FindNodeByKey(8).Node);
        }

        [TestMethod]
        public void TestDeleteNodeByKey_DeleteNodeWithRightChild()
        {
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);
            bst.AddKeyValue(7, 7);
            bst.AddKeyValue(9, 9);

            
            bool result = bst.DeleteNodeByKey(8);


            Assert.IsTrue(result);
            Assert.IsNull(bst.FindNodeByKey(8).Node);
        }

        [TestMethod]
        public void TestDeleteNodeByKey_DeleteNodeWithLeftChild()
        {
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);
            bst.AddKeyValue(2, 2);
            bst.AddKeyValue(4, 4);

            bool result = bst.DeleteNodeByKey(3);

            Assert.IsTrue(result);
            Assert.IsNull(bst.FindNodeByKey(3).Node);
        }

        [TestMethod]
        public void TestDeleteNodeByKey_DeleteNodeWithTwoChildren()
        {
            
            BST<int> bst = new BST<int>(null);
            bst.AddKeyValue(5, 5);
            bst.AddKeyValue(3, 3);
            bst.AddKeyValue(8, 8);
            bst.AddKeyValue(2, 2);
            bst.AddKeyValue(4, 4);
            bst.AddKeyValue(7, 7);
            bst.AddKeyValue(9, 9);

            
            bool result = bst.DeleteNodeByKey(5);

            
            Assert.IsTrue(result);
            Assert.IsNull(bst.FindNodeByKey(5).Node);
        }

    }

    
}
