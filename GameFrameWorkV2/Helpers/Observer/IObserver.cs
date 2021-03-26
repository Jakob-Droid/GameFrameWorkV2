using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Creatures;

namespace GameFrameWorkV2.Helpers.Observer
{
    public interface IObserver
    {
        void Notify(Creature creature);
    }
}
