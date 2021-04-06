using System;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException(string message) : base(message)
        {}
    }
}
