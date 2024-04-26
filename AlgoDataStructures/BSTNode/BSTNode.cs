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

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FindMax)
                return FindMaxKey(FromNode);

            return FindMinKey(FromNode);
        }

        private BSTNode<T> FindMaxKey(BSTNode<T> node)
        {
            if (node.RightChild == null)
                return node;

            return FindMaxKey(node.RightChild);
        }

        private BSTNode<T> FindMinKey(BSTNode<T> node)
        {
            if (node.LeftChild == null)
                return node;

            return FindMinKey(node.LeftChild);
        }

        private void SetParentChild(BSTFind<T> foundNode, int key)
        {
            if (key < foundNode.Node.Parent.NodeKey)
            {
                foundNode.Node.Parent.LeftChild = foundNode.Node.LeftChild;
                foundNode.Node.LeftChild.Parent = foundNode.Node.Parent;
            }
            else
            {
                foundNode.Node.Parent.RightChild = foundNode.Node.LeftChild;
                foundNode.Node.LeftChild.Parent = foundNode.Node.Parent;
            }
        }

        private void NodeToNull(BSTFind<T> foundNode, int key)
        {
            if (foundNode.Node == Root)
            {
                Root = null;
            }
            else if (key < foundNode.Node.Parent.NodeKey)
            {
                foundNode.Node.Parent.LeftChild = null;
            }
            else
            {
                foundNode.Node.Parent.RightChild = null;
            }
        }

        public bool DeleteNodeByKey(int key)
        {
            BSTFind<T> foundNode = FindNodeByKey(key);
            if (!foundNode.NodeHasKey)
            {
                return false;
            }

            if (foundNode.Node.RightChild != null)
            {
                BSTNode<T> minNode = FinMinMax(foundNode.Node.RightChild, false);
                int temp = minNode.NodeKey;
                DeleteNodeByKey(temp);
                foundNode.Node.NodeKey = temp;
            }

            if (foundNode.Node.LeftChild != null && foundNode.Node.RightChild == null)
            {
                SetParentChild(foundNode, key);
            }

            if (foundNode.Node.LeftChild == null && foundNode.Node.RightChild == null)
            {
                NodeToNull(foundNode, key);
            }
            return true;
        }

        private int GetSize(BSTNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetSize(node.LeftChild) + GetSize(node.RightChild) + 1;
        }

        public int Count()
        {
            return GetSize(Root);
        }

        public List<BSTNode<T>> WideAllNodes()
        {
            List<BSTNode<T>> WideList = new List<BSTNode<T>>();
            Queue<BSTNode<T>> NodesQueue = new Queue<BSTNode<T>>();

            if (Root != null)
            {
                NodesQueue.Enqueue(Root);

                while (NodesQueue.Count > 0)
                {
                    BSTNode<T> node = NodesQueue.Dequeue();
                    WideList.Add(node);

                    if (node.LeftChild != null)
                        NodesQueue.Enqueue(node.LeftChild);
                    if (node.RightChild != null)
                        NodesQueue.Enqueue(node.RightChild);
                }
            }
            return WideList;
        }

        public List<BSTNode<T>> DeepAllNodes(int Order)
        {
            return DeepTraversing(Root, Order);
        }

        private List<BSTNode<T>> DeepTraversing(BSTNode<T> fromNode, int Order)
        {
            List<BSTNode<T>> DeepList = new List<BSTNode<T>>();
            BSTNode<T> Node = fromNode;

            if (Node != null)
            {
                switch (Order)
                {
                    case 0:
                        {
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.Add(Node);
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));

                            break;
                        }

                    case 1:
                        {
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));
                            DeepList.Add(Node);

                            break;
                        }

                    case 2:
                        {
                            DeepList.Add(Node);
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));
                            break;
                        }

                    default:
                        return null;
                }
            }
            return DeepList;
        }
    }
}