using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items.ConcreteAttackItems
{
    public class Bow : AttackItem
    {
        public Bow(int damage, string name, int range) : base(damage, name)
        {
            Type = "Bow";
            Range = range;
        }
    }
}
