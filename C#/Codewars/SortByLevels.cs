namespace Codewars
{
    using System.Collections.Generic;

    public static partial class Kata
    {
        public static List<int> TreeByLevels(Node? node)
        {
            if (node == null)
            {
                return new List<int>();
            }

            var nodeQueue = new Queue<Node>();
            var sorted = new List<int>();

            nodeQueue.Enqueue(node);
            while (nodeQueue.TryDequeue(out var nextNode))
            {
                // Add this node's value to the list
                sorted.Add(nextNode.Value);

                // Then add left child + right child to be processed later
                if (nextNode.Left != null)
                {
                    nodeQueue.Enqueue(nextNode.Left);
                }

                if (nextNode.Right != null)
                {
                    nodeQueue.Enqueue(nextNode.Right);
                }
            }

            return sorted;
        }
    }

    public class Node
    {
        public Node? Left;
        public Node? Right;
        public int Value;

        public Node(Node? l, Node? r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }
}
