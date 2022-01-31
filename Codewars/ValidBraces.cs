// Goal for this one is to determine if a set of braces is correct or not.
// Unlike the normal version, this one allows (), [] and {}.

namespace Codewars
{
    using System.Collections.Generic;

    public class Brace
    {
        public static bool validBraces(string braces)
        {
            var stack = new Stack<char>();
            foreach (char c in braces)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    // If stack is currently empty, we're closing a non-existent pair
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    // Otherwise, see if we're closing the correct brace
                    var opening = stack.Peek();
                    switch ((opening, c))
                    {
                        case ('(', ')'):
                        case ('[', ']'):
                        case ('{', '}'):
                            stack.Pop();
                            break;
                        default:
                            return false;
                    }
                }
            }

            // Valid if there are no more open braces
            return stack.Count == 0;
        }
    }
}
