using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class YouAreDeadException: Exception
    {
        public YouAreDeadException(string message):base(message)
        {
        }
    }
}
