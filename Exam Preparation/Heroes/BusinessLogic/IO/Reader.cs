namespace Heroes.IO
{
    using Heroes.IO.Contracts;
    using System;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
