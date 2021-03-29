using System;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class PositionAlreadyOccupiedException : Exception
    {
        public PositionAlreadyOccupiedException(string message) : base(message)
        {

        }
    }
}
