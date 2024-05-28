using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public int NodeLevel;
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = new List<SimpleTreeNode<T>>();
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            if (Root == null)
                return new List<SimpleTreeNode<T>>();

            return GetNodes(Root);
        }

        private List<SimpleTreeNode<T>> GetNodes(SimpleTreeNode<T> rootNode)
        {
            List<SimpleTreeNode<T>> nodes = new List<SimpleTreeNode<T>>();
            nodes.Add(rootNode);

            if (rootNode.Children == null || rootNode.Children.Count == 0)
            {
                return nodes;
            }

            foreach (SimpleTreeNode<T> node in rootNode.Children)
            {
                nodes.AddRange(GetNodes(node));
            }

            return nodes;
        }

        public int Count()
        {
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                return AllNodes.Count;
            }
            return 0;
        }

        public List<T> EvenTrees()
        {
            List<T> deletedEdges = new List<T>();
            if (Root == null) return deletedEdges;

            DepthFirstSearch(Root, deletedEdges);
            return deletedEdges;
        }

        private int DepthFirstSearch(SimpleTreeNode<T> node, List<T> deletedEdges)
        {
            int subtreeNodeCount = 1;
            foreach (var child in node.Children)
            {
                int childCount = DepthFirstSearch(child, deletedEdges);
                subtreeNodeCount += childCount;
                if (childCount % 2 == 0)
                {
                    deletedEdges.Add(node.NodeValue);
                    deletedEdges.Add(child.NodeValue);
                }
            }
            return subtreeNodeCount;
        }
    }
}
