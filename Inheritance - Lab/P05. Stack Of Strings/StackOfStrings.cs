using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (var item in elements)
            {
                Push(item);
            }
            return this;
        }
    }
}
