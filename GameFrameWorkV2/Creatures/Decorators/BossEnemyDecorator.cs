using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class BossEnemyDecorator : AbstractEnemyDecorator
    {
        public BossEnemyDecorator(AbstractCreature creature):base(creature)
        {
            Name = $"A very dangerous {creature.Name}";
            HitPoints += 200;
            Position = creature.Position;
        }
    }
}
