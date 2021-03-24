using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class AbstractEnemyDecorator : Creature
    {

        //Hvorfor skal jeg bruge en creature her???
        public Creature Creature { get; set; }

        public AbstractEnemyDecorator(Creature creature)
        {
            Creature = creature;
        }
    }
}
