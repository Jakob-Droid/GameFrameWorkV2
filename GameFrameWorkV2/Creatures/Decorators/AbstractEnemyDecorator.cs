using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    //Should this inherit from EnemyCreature or Creature???
    public class AbstractEnemyDecorator : EnemyCreature
    {

        //Hvorfor skal jeg bruge en creature her???
        public AbstractCreature Creature { get; set; }


        public AbstractEnemyDecorator(AbstractCreature creature) : base(creature.HitPoints, creature.Name, creature.Position)
        {
            Creature = creature;
        }
    }
}
