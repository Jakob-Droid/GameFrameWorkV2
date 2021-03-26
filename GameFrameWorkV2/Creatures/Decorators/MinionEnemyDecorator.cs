using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class MinionEnemyDecorator : AbstractEnemyDecorator
    {
        public MinionEnemyDecorator(AbstractCreature creature):base(creature)
        {
            Name = $"A feeble {creature.Name}";
            HitPoints -= 5;
            Position = creature.Position;
        }


    }
}
