using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items.ConcreteItems
{
    public class Armour : DefenceItem
    {
        public Armour(string name, int reduceHitPoints) : base(name, reduceHitPoints)
        {
            Type = "Armour";
        }
    }
}
