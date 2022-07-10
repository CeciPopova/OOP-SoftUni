namespace Telephony.Models
{
    using Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
        //    private bool ValidateNumber(string number)
        //    {
        //        foreach (var item in number)
        //        {
        //            if (!char.IsDigit(item))
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
    }
}
