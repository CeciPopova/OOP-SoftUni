namespace AquaShop.IO
{
    using AquaShop.IO.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}