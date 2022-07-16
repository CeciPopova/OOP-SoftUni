namespace WildFarm.Exception
{
    using System;
    public class FoodNotPreferedException : Exception
    {

        public FoodNotPreferedException(string message)
            : base(message)
        {

        }
    }
}
