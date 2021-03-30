using GameFrameWorkV2.Items.ConcreteAttackItems;
using GameFrameWorkV2.Items.ConcreteDefenceItems;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Creatures
{
    public interface ICreature
    {
        int HitPoints { get; set; }
        string Name { get; set; }

        abstract void Hit(ICreature defender);

        abstract void Loot(World world, string itemName);

        abstract void ReceiveHit(int damage);
        public CompositeDefence DefencesItems { get; set; }
        public CompositeAttack AttackItems { get; set; }
    }
}
