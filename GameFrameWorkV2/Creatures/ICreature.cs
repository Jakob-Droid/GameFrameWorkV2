using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Items;

namespace GameFrameWorkV2.Creatures
{
    public interface ICreature
    {
        int HitPoints { get; set; }
        string Name { get; set; }

        abstract void Hit(ICreature defender);

        abstract void Loot(IItem item);

        abstract void ReceiveHit(int damage);
    }
}
