﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Helpers.Observer
{
    public interface IObservable
    {
       void AddObserver(IObserver observer);
    }
}