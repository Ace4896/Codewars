// NOTE:
// - Local tests won't work here since there's a helper method in the tests...
// - There's proper algorithms for cycle detection - mine was just brute force
// - https://en.wikipedia.org/wiki/Cycle_detection

namespace Codewars
{
    using System.Collections.Generic;

    public static partial class Kata
    {
        public static int getLoopSize(LoopDetector.Node startNode)
        {
            // Keep track of each node and their "index" in the linked list
            // Using a regular list is too slow, since we have to linearly search it
            // But dictionaries use hashes to locate the key, so much faster with larger linked lists
            var traversed = new Dictionary<LoopDetector.Node, int> { { startNode, 0 } };
            var current = startNode.next;
            var index = 1;
            while (!traversed.ContainsKey(current))
            {
                traversed.Add(current, index);
                current = current.next;
                index++;
            }

            var loopStart = traversed[current];
            return traversed.Count - loopStart;
        }
    }
}

namespace Codewars.LoopDetector
{
    public class Node
    {
        public Node next { get; set; } = null!;
    }
}
