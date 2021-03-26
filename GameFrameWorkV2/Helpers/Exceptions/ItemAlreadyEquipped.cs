using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class ItemAlreadyEquipped:Exception
    {
        public ItemAlreadyEquipped(string message) : base(message)
        {

        }
    }
}
