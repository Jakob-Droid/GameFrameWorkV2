using System;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class ItemAlreadyEquipped : Exception
    {
        public ItemAlreadyEquipped(string message) : base(message)
        {

        }
    }
}
