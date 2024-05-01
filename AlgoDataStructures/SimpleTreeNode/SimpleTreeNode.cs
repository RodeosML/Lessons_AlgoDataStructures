using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures3
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
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
            Root.NodeLevel = 0;
        }

        private void AddLevels(SimpleTreeNode<T> Root)
        {
            if (Root.Children == null || Root.Children.Count == 0) return;
            foreach (SimpleTreeNode<T> node in Root.Children)
            {
                node.NodeLevel = Root.NodeLevel + 1;
                AddLevels(node);
            }
        }

        public void AddNodesLevels()
        {
            if (Root != null)
            {
                Root.NodeLevel = 0;
                AddLevels(Root);
            }
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode
            if (ParentNode.Children == null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
            }

            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
            NewChild.NodeLevel = NewChild.Parent.NodeLevel + 1;
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

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
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
            if (Root != null)
            {
                SimpleTreeNode<T> OldParent;
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                foreach (SimpleTreeNode<T> node in AllNodes)
                {
                    if (node == OriginalNode)
                    {
                        OldParent = node.Parent;
                        node.Parent = NewParent;
                        AddChild(NewParent, node);
                        OldParent.Children.Remove(node);
                        if (OldParent.Children.Count == 0)
                        {
                            OldParent.Children = null;
                        }
                        return;
                    }
                }
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

        private int GetLeafs(SimpleTreeNode<T> root)
        {
            if (root.Children == null || !root.Children.Any())
                return 1;
            int leafs = 0;

            foreach (SimpleTreeNode<T> node in root.Children)
            {
                leafs += GetLeafs(node);
            }
            return leafs;
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            if (Root == null)
                return 0;
            return GetLeafs(Root);
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

        public List<T> EvenTrees()
        {
            List<T> deletedEdges = new List<T>();
            Queue<SimpleTreeNode<T>> queue = new Queue<SimpleTreeNode<T>>();
            SimpleTreeNode<T> node = Root;
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                SimpleTree<T> tree = new SimpleTree<T>(node);
                if ((tree.Count() & 1) == 0)
                {
                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
                if ((tree.Count() & 1) == 0 && node.Parent != null)
                {
                    deletedEdges.Add(node.Parent.NodeValue);
                    deletedEdges.Add(node.NodeValue);
                }
            }
            return deletedEdges;
        }

    }

}