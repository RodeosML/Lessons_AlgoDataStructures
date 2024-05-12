using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BalancedBST
    {
        public BSTNode Root; // корень дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            Array.Sort(a);
            Generate(null, a);
        }

        private BSTNode Generate(BSTNode parent, int[] array)
        {
            if (array.Length == 0) return null;

            int centerIndex = array.Length / 2;
            BSTNode node = new BSTNode(array[centerIndex], parent);

            if (Root == null)
            {
                Root = node;
                Root.Level = 0;
            }

            if (node.Parent != null)
                node.Level = node.Parent.Level + 1;

            node.LeftChild = Generate(node, new ArraySegment<int>(array, 0, centerIndex).ToArray());
            node.RightChild = Generate(node, new ArraySegment<int>(array, centerIndex + 1, array.Length - centerIndex - 1).ToArray());

            return node;
        }

        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node == null) return true;

            int maxLeftLevel = GetMaxLevel(root_node.LeftChild);
            int maxRightLevel = GetMaxLevel(root_node.RightChild);
            int margin = Math.Abs(maxLeftLevel - maxRightLevel);

            return margin <= 1 && IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild);
        }

        private int GetMaxLevel(BSTNode node)
        {
            if (node == null) return 0;

            return Math.Max(node.Level, Math.Max(GetMaxLevel(node.LeftChild), GetMaxLevel(node.RightChild)));
        }
    }
}
