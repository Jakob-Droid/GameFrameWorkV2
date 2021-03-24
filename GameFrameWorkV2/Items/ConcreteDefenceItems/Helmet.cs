using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items.ConcreteDefenceItems
{
    public class Helmet : DefenceItem
    {
        public Helmet(string name, int reduceHitPoints) : base(name, reduceHitPoints)
        {
            Type = "Helmet";
        }
    }
}
