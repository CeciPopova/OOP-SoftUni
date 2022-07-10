using Telephony.IO.Interfaces;

namespace Telephony.Core
{
    using Models;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;
        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in phoneNumbers)
            {
                if (!this.ValidateNumber(item))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (item.Length == 10)
                {
                    this.writer.WriteLine(this.smartphone.Call(item));
                }
                else if (item.Length == 7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(item));
                }
            }
            foreach (var url in urls)
            {
                if (!this.ValidateURL(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartphone.BrowseURL(url));
                }
            }
        }
        private bool ValidateNumber(string number)
        {
            foreach (var item in number)
            {
                if (!char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateURL(string url)
        {
            foreach (var item in url)
            {
                if (char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
