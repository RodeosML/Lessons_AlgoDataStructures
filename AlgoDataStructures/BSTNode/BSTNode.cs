using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
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
            // добавляем ключ-значение в дерево
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
            // ищем максимальный/минимальный ключ в поддереве
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
            //Проверяем, что есть правый потомок
            if (foundNode.Node.RightChild != null)
            {
                BSTNode<T> minNode = FinMinMax(foundNode.Node.RightChild, false);
                int temp = minNode.NodeKey;
                DeleteNodeByKey(temp);
                foundNode.Node.NodeKey = temp;
            }
            //Проверяем, что есть левый потомок
            if (foundNode.Node.LeftChild != null && foundNode.Node.RightChild == null)
            {
                SetParentChild(foundNode, key);
            }
            //Проверяем, что нет потомков
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
            return GetSize(Root); // количество узлов в дереве
        }

        public List<BSTNode<T>> WideAllNodes()
        {
            List<BSTNode<T>> WideList = new List<BSTNode<T>>();
            Queue<BSTNode<T>> NodesQueue = new Queue<BSTNode<T>>();
            BSTNode<T> Node = Root;
            NodesQueue.Enqueue(Root);

            if (Root != null)
            {
                while (NodesQueue.Count > 0)
                {
                    Node = NodesQueue.Dequeue();
                    WideList.Add(Node);

                    if (Node.LeftChild != null)
                        NodesQueue.Enqueue(Node.LeftChild);
                    if (Node.RightChild != null)
                        NodesQueue.Enqueue(Node.RightChild);
                }
                return WideList;
            }
            return null;
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
                    case 0: //in-order
                        {
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.Add(Node);
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));

                            break;
                        }

                    case 1: //post-order
                        {
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));
                            DeepList.Add(Node);

                            break;
                        }

                    case 2: //pre-order
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