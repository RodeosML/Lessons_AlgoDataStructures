using AlgorithmsDataStructures2;

namespace SimpleGraphTests
{
    [TestClass]
    public class SimpleTreeTests
    {
        [TestMethod]
        public void Test_EvenTrees_NoRemovals()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            var result = tree.EvenTrees();

            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void Test_EvenTrees_SingleRemoval()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, root);
            root.Children.Add(node2);

            var tree = new SimpleTree<int>(root);

            var result = tree.EvenTrees();

            CollectionAssert.AreEqual(new List<int>(), result);
        }

        //[TestMethod]
        //public void Test_EvenTrees_MultipleRemovals()
        //{
        //    var root = new SimpleTreeNode<int>(1, null);
        //    var node2 = new SimpleTreeNode<int>(2, root);
        //    var node3 = new SimpleTreeNode<int>(3, root);
        //    var node4 = new SimpleTreeNode<int>(4, node2);
        //    var node5 = new SimpleTreeNode<int>(5, node2);
        //    var node6 = new SimpleTreeNode<int>(6, node3);
        //    var node7 = new SimpleTreeNode<int>(7, node3);

        //    root.Children.Add(node2);
        //    root.Children.Add(node3);
        //    node2.Children.Add(node4);
        //    node2.Children.Add(node5);
        //    node3.Children.Add(node6);
        //    node3.Children.Add(node7);

        //    var tree = new SimpleTree<int>(root);

        //    var result = tree.EvenTrees();

        //    CollectionAssert.AreEqual(new List<int> { 1, 2, 1, 3 }, result);
        //}

        //[TestMethod]
        //public void Test_EvenTrees_ComplexTree()
        //{
        //    var root = new SimpleTreeNode<int>(1, null);
        //    var node2 = new SimpleTreeNode<int>(2, root);
        //    var node3 = new SimpleTreeNode<int>(3, root);
        //    var node4 = new SimpleTreeNode<int>(4, node2);
        //    var node5 = new SimpleTreeNode<int>(5, node2);
        //    var node6 = new SimpleTreeNode<int>(6, node3);
        //    var node7 = new SimpleTreeNode<int>(7, node6);
        //    var node8 = new SimpleTreeNode<int>(8, node6);

        //    root.Children.Add(node2);
        //    root.Children.Add(node3);
        //    node2.Children.Add(node4);
        //    node2.Children.Add(node5);
        //    node3.Children.Add(node6);
        //    node6.Children.Add(node7);
        //    node6.Children.Add(node8);

        //    var tree = new SimpleTree<int>(root);

        //    var result = tree.EvenTrees();

        //    CollectionAssert.AreEqual(new List<int> { 3, 6, 1, 3 }, result);
        //}
    }
}
