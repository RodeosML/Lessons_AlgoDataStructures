using System;
using System.Collections.Generic;

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

        public static explicit operator BSTNode(BSTNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.GetType() != typeof(BSTNode<int>))
            {
                throw new Exception("Должно быть int");
            }

            BSTNode newNode = new BSTNode(node.NodeKey, Convert.ToInt32(node.NodeValue), null);

            return newNode;
        }
    }



    public class BSTNode : BSTNode<int>
    {
        public BSTNode(int key, int val, BSTNode<int> parent) : base(key, val, parent)
        {
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

        public BSTFind<T> FindNodeByKey(int key)
        {
            if (Root == null)
                return new BSTFind<T>();

            return FindNode(Root, key);
        }

        private BSTFind<T> FindNode(BSTNode<T> node, int key)
        {
            if (key == node.NodeKey)
            {
                BSTFind<T> foundNode = new BSTFind<T>();
                foundNode.Node = node;
                foundNode.NodeHasKey = true;
                return foundNode;
            }

            if (key < node.NodeKey && node.LeftChild == null)
            {
                BSTFind<T> foundNode = new BSTFind<T>();
                foundNode.Node = node;
                foundNode.NodeHasKey = false;
                foundNode.ToLeft = true;
                return foundNode;
            }

            if (key > node.NodeKey && node.RightChild == null)
            {
                BSTFind<T> foundNode = new BSTFind<T>();
                foundNode.Node = node;
                foundNode.NodeHasKey = false;
                foundNode.ToLeft = false;
                return foundNode;
            }

            if (key < node.NodeKey)
            {
                return FindNode(node.LeftChild, key);
            }

            return FindNode(node.RightChild, key);
        }

        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> foundNode = FindNodeByKey(key);
            if (foundNode.NodeHasKey)
            {
                return false;
            }

            BSTNode<T> newNode = new BSTNode<T>(key, val, foundNode.Node);
            if (foundNode.Node == null)
            {
                Root = newNode;
            }
            else if (foundNode.ToLeft)
            {
                foundNode.Node.LeftChild = newNode;
            }
            else
            {
                foundNode.Node.RightChild = newNode;
            }
            return true;
        }

        public List<BSTNode> WideAllNodes()
        {
            List<BSTNode> result = new List<BSTNode>();

            if (Root == null)
            {
                return result;
            }

            Queue<BSTNode<T>> nodes = new Queue<BSTNode<T>>();
            nodes.Enqueue(Root);

            while (nodes.Count != 0)
            {
                BSTNode<T> currentElement = nodes.Dequeue();
                result.Add((BSTNode)currentElement);

                if (currentElement.LeftChild != null)
                {
                    nodes.Enqueue(currentElement.LeftChild);
                }

                if (currentElement.RightChild != null)
                {
                    nodes.Enqueue(currentElement.RightChild);
                }
            }

            return result;
        }

        public List<BSTNode> DeepAllNodes(int option)
        {
            List<BSTNode> result = new List<BSTNode>();

            if (Root == null)
            {
                return result;
            }

            switch (option)
            {
                case 0:
                    PreOrder(result, Root);
                    break;
                case 1:
                    InOrder(result, Root);
                    break;
                case 2:
                    PostOrder(result, Root);
                    break;
            }

            return result;
        }

        private void PreOrder(List<BSTNode> result, BSTNode<T> node)
        {
            if (node != null)
            {
                result.Add((BSTNode)node);
                PreOrder(result, node.LeftChild);
                PreOrder(result, node.RightChild);
            }
        }

        private void InOrder(List<BSTNode> result, BSTNode<T> node)
        {
            if (node != null)
            {
                result.Add((BSTNode)node);
                InOrder(result, node.LeftChild);
                InOrder(result, node.RightChild);
            }
        }

        private void PostOrder(List<BSTNode> result, BSTNode<T> node)
        {
            if (node != null)
            {
                result.Add((BSTNode)node);
                PostOrder(result, node.LeftChild);
                PostOrder(result, node.RightChild);
            }
        }
    }

}