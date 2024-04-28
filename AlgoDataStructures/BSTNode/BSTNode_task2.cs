using System;
using System.Collections.Generic;
using AlgorithmsDataStructures1;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey;
        public T NodeValue;
        public BSTNode<T> Parent;
        public BSTNode<T> LeftChild;
        public BSTNode<T> RightChild;

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTFind<T>
    {
        public BSTNode<T> Node;

        public bool NodeHasKey;

        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root;

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public List<BSTNode> WideAllNodes()
        {
            List<BSTNode> listOfNodes = new List<BSTNode>();

            Queue<BSTNode<T>> NodesQueue = new Queue<BSTNode<T>>();
            NodesQueue.Enqueue(Root);

            while (NodesQueue.Count > 0)
            {
                var currentNode = NodesQueue.Dequeue();
                var bstNode = new BSTNode(currentNode.NodeKey);
                listOfNodes.Add(bstNode);

                if (currentNode.LeftChild != null)
                {
                    NodesQueue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    NodesQueue.Enqueue(currentNode.RightChild);
                }
            }

            return listOfNodes;
        }

        public List<BSTNode> DeepAllNodes(int order)
        {
            return DeepTraversing(Root, order);
        }

        private List<BSTNode> DeepTraversing(BSTNode<T> node, int order)
        {
            List<BSTNode> listOfNodes = new List<BSTNode>();

            if (node == null) return listOfNodes;

            switch (order)
            {
                case 0:
                    listOfNodes.AddRange(DeepTraversing(node.LeftChild, order));
                    listOfNodes.Add(new BSTNode(node.NodeKey));
                    listOfNodes.AddRange(DeepTraversing(node.RightChild, order));
                    break;
                case 1:
                    listOfNodes.AddRange(DeepTraversing(node.LeftChild, order));
                    listOfNodes.AddRange(DeepTraversing(node.RightChild, order));
                    listOfNodes.Add(new BSTNode(node.NodeKey));
                    break;
                case 2:
                    listOfNodes.Add(new BSTNode(node.NodeKey));
                    listOfNodes.AddRange(DeepTraversing(node.LeftChild, order));
                    listOfNodes.AddRange(DeepTraversing(node.RightChild, order));
                    break;
                default:
                    break;
            }

            return listOfNodes;
        }
    }

    public class BSTNode
    {
        public int NodeKey;

        public BSTNode(int key)
        {
            NodeKey = key;
        }
    }

}