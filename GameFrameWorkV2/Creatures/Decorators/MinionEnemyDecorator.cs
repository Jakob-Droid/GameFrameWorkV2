using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class MinionEnemyDecorator : Creature
    {
        protected readonly ICreature Creature;
        public MinionEnemyDecorator(Creature creature)
        {
            Creature = creature;
            creature.Name = $"A feeble {creature.Name}";
            creature.HitPoints -= 5;
        }


    }
}
