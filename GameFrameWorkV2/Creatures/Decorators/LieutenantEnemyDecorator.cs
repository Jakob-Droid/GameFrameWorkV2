using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class LieutenantEnemyDecorator : AbstractEnemyDecorator
    {
        
        public LieutenantEnemyDecorator(AbstractCreature creature): base(creature)
        {
            Name = $"An important {creature.Name}";
            HitPoints +=20;
            Position = creature.Position;
        }
    }
}
