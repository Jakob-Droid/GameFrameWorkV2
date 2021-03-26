using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class AbstractEnemyDecorator : Creature
    {

        //Hvorfor skal jeg bruge en creature her???
        public Creature Creature { get; set; }


        public AbstractEnemyDecorator(Creature creature) : base(creature.HitPoints, creature.Name, creature.Position)
        {
            Creature = creature;
        }
    }
}
