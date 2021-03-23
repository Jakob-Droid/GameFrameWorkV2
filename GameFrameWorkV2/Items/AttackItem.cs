using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items
{
    public class AttackItem : IItem
    {
        public int Damage { get; set; }
        public string Name { get; set; }
        public int Range { get; set; }

        public AttackItem(int damage, string name, int range)
        {
            Damage = damage;
            Name = name;
            Range = range;
        }
    }
}
