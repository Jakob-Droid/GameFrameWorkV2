using GameFrameWorkV2.Creatures.ConcreteCreatures;

namespace GameFrameWorkV2.Creatures.Decorators
{
    public class AbstractEnemyDecorator : EnemyCreature
    {
        public AbstractCreature Creature { get; set; }
        public AbstractEnemyDecorator(AbstractCreature creature) : base(creature.HitPoints, creature.Name, creature.Position)
        {
            Creature = creature;
            Position = creature.Position;
        }
    }
}
