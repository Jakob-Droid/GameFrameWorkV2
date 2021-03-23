using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class LieutenantEnemyDecorator : Creature
    {
        protected readonly ICreature Creature;
        public LieutenantEnemyDecorator(Creature creature)
        {
            Creature = creature;
            creature.Name = $"An important {creature.Name}";
            creature.HitPoints +=20;
        }
    }
}
