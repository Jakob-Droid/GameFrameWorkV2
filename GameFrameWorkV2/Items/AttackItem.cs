using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items
{
    public abstract class AttackItem : IItem
    {
        public virtual int Damage { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Range { get; set; }

        protected AttackItem(int damage, string name)
        {
            Damage = damage;
            Name = name;
        }

        public AttackItem()
        {
            
        }
    }
}
