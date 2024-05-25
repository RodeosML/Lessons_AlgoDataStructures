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

        public List<T> EvenTrees()
        {
            List<T> result = new List<T>();
            CountNodesAndFindEdgesToRemove(Root, result);
            return result;
        }

        private int CountNodesAndFindEdgesToRemove(SimpleTreeNode<T> node, List<T> result)
        {
            int count = 1;
            foreach (var child in node.Children)
            {
                int childCount = CountNodesAndFindEdgesToRemove(child, result);
                if (childCount % 2 == 0)
                {
                    result.Add(node.NodeValue);
                    result.Add(child.NodeValue);
                }
                else
                {
                    count += childCount;
                }
            }
            return count;
        }
    }
}