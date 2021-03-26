using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Creatures.ConcreteCreatures
{
    public class PlayerCreature : AbstractCreature
    {
        private World _world;
        public PlayerCreature(int hitPoints, string name, Position position, World world) : base(hitPoints, name, position)
        {
            _world = world;
        }
    }
}
