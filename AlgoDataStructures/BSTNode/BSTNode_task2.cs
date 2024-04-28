using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey;
        public object NodeValue;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;

        public BSTNode(int key, object val, BSTNode parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BST
    {
        public BSTNode Root { get; set; }

        public List<BSTNode> WideAllNodes()
        {
            List<BSTNode> WideList = new List<BSTNode>();
            Queue<BSTNode> NodesQueue = new Queue<BSTNode>();

            if (Root != null)
            {
                NodesQueue.Enqueue(Root);

                while (NodesQueue.Count > 0)
                {
                    BSTNode node = NodesQueue.Dequeue();
                    WideList.Add(node);

                    if (node.LeftChild != null)
                        NodesQueue.Enqueue(node.LeftChild);
                    if (node.RightChild != null)
                        NodesQueue.Enqueue(node.RightChild);
                }
            }
            return WideList;
        }

        public List<BSTNode> DeepAllNodes(int Order)
        {
            return DeepTraversing(Root, Order);
        }

        private List<BSTNode> DeepTraversing(BSTNode fromNode, int Order)
        {
            List<BSTNode> DeepList = new List<BSTNode>();
            BSTNode Node = fromNode;

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
