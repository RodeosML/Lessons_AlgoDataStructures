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
            // создаём дерево с нуля из неотсортированного массива a
            // ...
            Array.Sort(a);
            Generate(null, a);
        }

        private BSTNode Generate(BSTNode parent, int[] array)
        {

            if (array.Length == 0)
                return null;

            int centerIndex = array.Length / 2;

            BSTNode node = new BSTNode(array[array.Length / 2], parent);

            if (Root == null)
            {
                Root = node;
                Root.Level = 1;
            }

            if (node.Parent != null)
                node.Level = node.Parent.Level + 1;

            int[] leftArrWithoutMid = new int[centerIndex];
            int[] rightArrWithoutMid = new int[array.Length - leftArrWithoutMid.Length - 1];
            Array.Copy(array, 0, leftArrWithoutMid, 0, leftArrWithoutMid.Length);
            Array.Copy(array, centerIndex + 1, rightArrWithoutMid, 0, rightArrWithoutMid.Length);

            node.LeftChild = Generate(node, leftArrWithoutMid);
            node.RightChild = Generate(node, rightArrWithoutMid);

            return node;
        }

        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node != null)
            {
                int maxLeftLevel = root_node.Level;
                int maxRightLevel = root_node.Level;
                int margin;

                if (root_node.LeftChild != null)
                {
                    List<BSTNode> AllChildrenLeft = GetAllChildren(root_node.LeftChild);
                    foreach (BSTNode item in AllChildrenLeft)
                    {
                        if (item.Level > maxLeftLevel)
                            maxLeftLevel = item.Level;
                    }
                }

                if (root_node.RightChild != null)
                {
                    List<BSTNode> AllChildrenRight = GetAllChildren(root_node.RightChild);
                    foreach (BSTNode item in AllChildrenRight)
                    {
                        if (item.Level > maxRightLevel)
                            maxRightLevel = item.Level;
                    }
                }

                margin = Math.Abs(maxLeftLevel - maxRightLevel);

                if (margin <= 1)
                    return true;
            }
            return false; // сбалансировано ли дерево с корнем root_node
        }

        private List<BSTNode> GetAllChildren(BSTNode node)
        {
            List<BSTNode> AllChildren = new List<BSTNode>();
            BSTNode Node = node;

            if (Node != null)
            {
                if (Node.LeftChild != null)
                {
                    AllChildren.Add(Node.LeftChild);
                    AllChildren.AddRange(GetAllChildren(Node.LeftChild));
                }

                if (Node.RightChild != null)
                {
                    AllChildren.Add(Node.RightChild);
                    AllChildren.AddRange(GetAllChildren(Node.RightChild));
                }

                return AllChildren;
            }
            else
                return null;
        }

    }
}