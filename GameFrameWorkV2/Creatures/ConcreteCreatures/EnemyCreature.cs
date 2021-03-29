using GameFrameWorkV2.Helpers.Structs;
using System;

namespace GameFrameWorkV2.Creatures.ConcreteCreatures
{
    public class EnemyCreature : AbstractCreature
    {
        public EnemyCreature(int hitPoints, string name, Position position) : base(hitPoints, name, position)
        {
        }

        public override void Hit(ICreature defender)
        {
            var damage = AttackItems.Damage + Strength;
            defender.ReceiveHit(damage);
            if (defender.HitPoints > 0)
            {
                Console.WriteLine($"You, {defender.Name} have been hit for {CalculateDamge(damage, defender)}, you have {defender.HitPoints} HP left");
            }
            else
            {
                Console.WriteLine($"Ohh NO! {defender.Name} is dead!");
            }
        }
    }
}
