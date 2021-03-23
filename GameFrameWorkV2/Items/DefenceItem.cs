using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items
{
    public class DefenceItem :IItem
    {
        public string Name { get; set; }
        public int ReduceHitPoints { get; set; }

        public DefenceItem(string name, int reduceHitPoints)
        {
            Name = name;
            ReduceHitPoints = reduceHitPoints;
        }
    }
}
