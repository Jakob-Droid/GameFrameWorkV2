using System;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class YouAreDeadException : Exception
    {
        public YouAreDeadException(string message) : base(message)
        {
        }
    }
}
