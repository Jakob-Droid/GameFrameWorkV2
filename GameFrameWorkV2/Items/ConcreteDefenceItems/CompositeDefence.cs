using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items.ConcreteDefenceItems
{
    public class CompositeDefence : DefenceItem
    {
        //TODO -- is this the right way to use this?
        public List<DefenceItem> DefenceItems { get; set; }
        public CompositeDefence(string name, int reduceHitPoints) : base(name, reduceHitPoints)
        {
        }

        public override int ReduceHitPoints
        {
            get
            {
                return DefenceItems.Sum(x => x.ReduceHitPoints);
            }
            set { base.ReduceHitPoints = value; }
        }
    }
}
