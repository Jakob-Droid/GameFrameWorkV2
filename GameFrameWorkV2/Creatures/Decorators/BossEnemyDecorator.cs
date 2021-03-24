﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class BossEnemyDecorator : Creature
    {
        protected readonly ICreature Creature;
        public BossEnemyDecorator(Creature creature)
        {
            Creature = creature;
            creature.Name = $"A very dangerous {creature.Name}";
            creature.HitPoints += 200;
        }
    }
}