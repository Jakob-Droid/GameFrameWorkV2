using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;

namespace GameFrameWorkV2.Creatures
{
    public abstract class Creature : ICreature
    {
        private Random rnd = new Random();
        public Position Position { get; set; }
        public int HitPoints { get; set; }
        public string Name { get; set; }
        public int DamageModifier { get; set; } = 1;

        protected Creature()
        {
            
        }

        protected Creature(int hitPoints, string name, Position position)
        {
            HitPoints = hitPoints;
            Name = name;
            Position = position;
        }


        public virtual void Hit(ICreature defender)
        {
            defender.HitPoints =- 10 * DamageModifier;
        }

        public virtual void Loot()
        {
            throw new NotImplementedException();
        }

        public virtual void ReceiveHit(ICreature attackCreature)
        {
            throw new NotImplementedException();

        }
    }
}
