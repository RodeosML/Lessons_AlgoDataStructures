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

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
            if (Root == null) return new BSTFind<T>();
            return FindNode(Root, key);
        }

        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            // если ключ уже есть
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

        private BSTNode<T> findMax(BSTNode<T> node)
        {
            if (node.RightChild == null) return node;
            return findMax(node.RightChild);
        }

        private BSTNode<T> findMin(BSTNode<T> node)
        {
            if (node.LeftChild == null) return node;
            return findMin(node.LeftChild);
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальный/минимальный ключ в поддереве
            if (FindMax)
            {
                return findMax(FromNode);
            }
            return findMin(FromNode);
        }

        public bool DeleteNodeByKey(int key)
        {
            return true;
        }

        private int getSize(BSTNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return getSize(node.LeftChild) + getSize(node.RightChild) + 1;
        }

        public int Count()
        {
            return getSize(Root); // количество узлов в дереве
        }

    }
}