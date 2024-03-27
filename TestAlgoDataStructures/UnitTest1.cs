using System;
using AlgorithmsDataStructures2;
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
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node1);
        node1.Children = new List<SimpleTreeNode<int>> { node2, node3 };

        SimpleTreeNode<int> newNode = new SimpleTreeNode<int>(4, null);

        SimpleTree<int> tree = new SimpleTree<int>(node1);

        tree.MoveNode(node2, newNode);

        Assert.AreEqual(newNode, node2.Parent);
        Assert.IsTrue(newNode.Children.Contains(node2));
        Assert.IsFalse(node1.Children.Contains(node2));
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
    public void LeafCount_ReturnsZeroForEmptyTree()
    {
        SimpleTree<int> tree = new SimpleTree<int>(null);

        int leafCount = tree.LeafCount();

        Assert.AreEqual(0, leafCount);
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


}
