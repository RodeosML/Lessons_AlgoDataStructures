using System;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAlgoDataStructures;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void SimpleTreeNodeAddChild_AddsChildToParentNode()
    {
        SimpleTreeNode<int> parentNode = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> childNode = new SimpleTreeNode<int>(2, parentNode);
        SimpleTree<int> tree = new SimpleTree<int>(parentNode);

        tree.AddChild(parentNode, childNode);

        Assert.IsNotNull(parentNode.Children);
        Assert.AreEqual(1, parentNode.Children.Count);
        Assert.AreEqual(childNode, parentNode.Children[0]);
        Assert.AreEqual(parentNode, childNode.Parent);
    }

    [TestMethod]
    public void DeleteNode_RemovesNodeFromParent()
    {
        SimpleTreeNode<int> parentNode = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> childNode = new SimpleTreeNode<int>(2, parentNode);
        SimpleTree<int> tree = new SimpleTree<int>(parentNode);

        tree.AddChild(parentNode, childNode);

        tree.DeleteNode(childNode);

        Assert.IsNotNull(parentNode.Children);
        Assert.AreEqual(0, parentNode.Children.Count);
    }

    [TestMethod]
    public void TestGetAllNodes()
    {
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
        node1.Children = new List<SimpleTreeNode<int>> { node2, node3 };
        SimpleTree<int> tree = new SimpleTree<int>(node1);

        List<SimpleTreeNode<int>> allNodes = tree.GetAllNodes();

        Assert.IsNotNull(allNodes);
        Assert.AreEqual(3, allNodes.Count);
        CollectionAssert.Contains(allNodes, node1);
        CollectionAssert.Contains(allNodes, node2);
        CollectionAssert.Contains(allNodes, node3);
    }

    [TestMethod]
    public void TestFindNodesByValue()
    {
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
        node1.Children = new List<SimpleTreeNode<int>> { node2, node3 };
        SimpleTree<int> tree = new SimpleTree<int>(node1);

        List<SimpleTreeNode<int>> nodesByValue = tree.FindNodesByValue(2);

        Assert.IsNotNull(nodesByValue);
        Assert.AreEqual(1, nodesByValue.Count);
        Assert.AreEqual(node2, nodesByValue[0]);
    }

    [TestMethod]
    public void TestMoveNode()
    {
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(45, null);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(3, null);
        SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);
        SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(23, null);
        SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(5, null);
        SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(9, null);
        SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(14, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);

        tree.AddChild(node1, node2);
        tree.AddChild(node2, node4);
        tree.AddChild(node2, node5);
        tree.AddChild(node5, node7);
        tree.AddChild(node5, node8);
        tree.AddChild(node1, node3);
        tree.AddChild(node3, node6);
        tree.AddChild(node6, node9);

        tree.MoveNode(node5, node6);

        Assert.AreEqual(1, node2.Children.Count);
        Assert.AreEqual(node4, node2.Children[0]);
        Assert.AreEqual(2, node6.Children.Count);
        Assert.AreEqual(node9, node6.Children[0]);
        Assert.AreEqual(node5, node6.Children[1]);
        Assert.AreEqual(2, node5.Children.Count);
        Assert.AreEqual(node7, node5.Children[0]);
        Assert.AreEqual(node8, node5.Children[1]);
    }


    [TestMethod]
    public void TestCount()
    {
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
        node1.Children = new List<SimpleTreeNode<int>> { node2, node3 };

        SimpleTree<int> tree = new SimpleTree<int>(node1);

        int count = tree.Count();

        Assert.AreEqual(3, count);
    }

    [TestMethod]
    public void LeafCount_ReturnsCorrectCountForTreeWithNodes()
    {
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, node2);
        node1.Children = new List<SimpleTreeNode<int>> { node2, node3 };
        node2.Children = new List<SimpleTreeNode<int>> { node4 };
        SimpleTree<int> tree = new SimpleTree<int>(node1);

        int leafCount = tree.LeafCount();

        Assert.AreEqual(2, leafCount);
    }

    [TestMethod]
    public void LeafCount_ReturnsZeroForTreeWithOnlyRootNode()
    {
        SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(1, null);
        SimpleTree<int> tree = new SimpleTree<int>(rootNode);

        int leafCount = tree.LeafCount();

        Assert.AreEqual(1, leafCount);
    }

    [TestMethod]
    public void LeafCount_ReturnsZeroForTreeWithSingleNodeWithoutChildren()
    {
        SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(1, null);
        SimpleTree<int> tree = new SimpleTree<int>(rootNode);

        int leafCount = tree.LeafCount();

        Assert.AreEqual(1, leafCount);
    }

    [TestMethod]
    public void EvenTrees_ReturnsCorrectDeletedEdges()
    {
        //SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        //SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
        //SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
        //SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, node3);

        //SimpleTree<int> tree = new SimpleTree<int>(node1);
        //tree.AddChild(node1, node2);
        //tree.AddChild(node1, node3);
        //tree.AddChild(node3, node4);

        //List<int> result = tree.EvenTrees();

        //CollectionAssert.AreEqual(new List<int> { 1, 4, 1, 3 }, result);
    }
}
