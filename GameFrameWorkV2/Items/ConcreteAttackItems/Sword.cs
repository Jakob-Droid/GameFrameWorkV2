using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items.ConcreteAttackItems
{
    public class Sword : AttackItem
    {
        public Sword(int damage, string name) : base(damage, name)
        {
            Type = "Sword";
            Range = 1;
        }
    }
}
