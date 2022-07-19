using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();
            if (true)
            {
                if (Count == 0)
                {
                    return null;
                }
                var index = rand.Next(0, base.Count);
                var element = base[index];
                base.RemoveAt(index);
                return element;
            }
        }


    }
}
