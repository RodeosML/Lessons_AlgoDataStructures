using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass]
    public class SimpleTreeTests
    {
        [TestMethod]
        public void TestEvenTrees()
        {
            SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, node1);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, node2);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, node3);
            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, node6);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, node7);
            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, node8);
            SimpleTreeNode<int> node10 = new SimpleTreeNode<int>(10, node8);

            node1.Children.AddRange(new List<SimpleTreeNode<int>> { node2, node3, node6 });
            node2.Children.Add(node7);
            node3.Children.Add(node4);
            node6.Children.Add(node8);
            node7.Children.Add(node5);
            node8.Children.AddRange(new List<SimpleTreeNode<int>> { node9, node10 });

            SimpleTree<int> tree = new SimpleTree<int>(node1);

            List<int> expectedEdges = new List<int> { 2, 7, 1, 3, 1, 6 };

            List<int> result = tree.EvenTrees();

            CollectionAssert.AreEqual(expectedEdges, result);
        }
    }
}
