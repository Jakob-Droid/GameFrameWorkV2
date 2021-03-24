﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Helpers.Exceptions
{
    public class PositionAlreadyOccupiedException : Exception
    {
        public PositionAlreadyOccupiedException(string message):base(message)
        {
            
        }
    }
}
