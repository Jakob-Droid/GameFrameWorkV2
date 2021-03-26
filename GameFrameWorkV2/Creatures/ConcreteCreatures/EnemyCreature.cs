using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.ConcreteCreatures
{
    public class EnemyCreature : AbstractCreature
    {
        public EnemyCreature(int hitPoints, string name, Position position) : base(hitPoints, name, position)
        {
        }
    }
}
