using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode
            if (ParentNode.Children == null)
                ParentNode.Children = new List<SimpleTreeNode<T>>();

            ParentNode.Children.Add(NewChild);
            ParentNode.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            // ваш код удаления существующего узла NodeToDelete
            if (Root == null || NodeToDelete == null)
            {
                return;
            }

            if (Root == NodeToDelete)
            {
                Root = null;
                return;
            }

            DeleteNodeRecursive(Root, NodeToDelete);
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = new List<SimpleTreeNode<T>>();
                AllNodes.Add(Root);
                AllNodes.AddRange(GetChildren(Root));
                return AllNodes;
            }
            return null;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            // ваш код поиска узлов по значению
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                List<SimpleTreeNode<T>> NodesByValue = new List<SimpleTreeNode<T>>();

                foreach (SimpleTreeNode<T> node in AllNodes)
                {
                    if (node.NodeValue.Equals(val))
                    {
                        NodesByValue.Add(node);
                    }
                }
                if (NodesByValue.Count > 0)
                {
                    return NodesByValue;
                }
            }
            return null;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            // ваш код перемещения узла вместе с его поддеревом -- 
            // в качестве дочернего для узла NewParent
            if (Root != null && OriginalNode != null && NewParent != null)
            {
                OriginalNode.Parent?.Children.Remove(OriginalNode);
                OriginalNode.Parent = NewParent;

                if (NewParent.Children == null)
                {
                    NewParent.Children = new List<SimpleTreeNode<T>>();
                }
                NewParent.Children.Add(OriginalNode);
            }
        }

        public int Count()
        {
            // количество всех узлов в дереве
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                return AllNodes.Count;
            }
            return 0;
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            if (Root == null)
            {
                return 0;
            }

            return CountLeaves(Root);
        }

        private int CountLeaves(SimpleTreeNode<T> node)
        {
            if (node.Children == null || node.Children.Count == 0)
            {
                return 1;
            }

            int count = 0;
            foreach (var child in node.Children)
            {
                count += CountLeaves(child);
            }

            return count;
        }

        public List<SimpleTreeNode<T>> GetChildren(SimpleTreeNode<T> Node)
        {
            List<SimpleTreeNode<T>> Children = new List<SimpleTreeNode<T>>();
            if (Node.Children != null)
            {
                foreach (SimpleTreeNode<T> node in Node.Children)
                {
                    Children.Add(node);
                    Children.AddRange(GetChildren(node));
                }
            }
            return Children;
        }

        private void DeleteNodeRecursive(SimpleTreeNode<T> currentNode, SimpleTreeNode<T> NodeToDelete)
        {
            if (currentNode.Children != null)
            {
                foreach (SimpleTreeNode<T> childNode in currentNode.Children)
                {
                    if (childNode == NodeToDelete)
                    {
                        currentNode.Children.Remove(childNode);
                        return;
                    }
                    else
                    {
                        DeleteNodeRecursive(childNode, NodeToDelete);
                    }
                }
            }
        }
    }

}