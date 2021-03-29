using GameFrameWorkV2.Helpers.Structs;
using System;

namespace GameFrameWorkV2.Creatures.ConcreteCreatures
{
    public class PlayerCreature : AbstractCreature
    {
        public PlayerCreature(int hitPoints, string name, Position position) : base(hitPoints, name, position)
        {
        }

        public override void Hit(ICreature defender)
        {
            var damage = AttackItems.Damage + Strength;
            defender.ReceiveHit(damage);
            if (defender.HitPoints > 0)
            {
                Console.WriteLine($"You hit the {defender.Name} for {CalculateDamge(damage, defender)}, it has {defender.HitPoints} HP left");
            }
            else
            {
                Console.WriteLine($"{defender.Name} is dead!");
            }
        }
        
    }
}
