namespace GameFrameWorkV2.Creatures.Decorators
{
    public class BossEnemyDecorator : AbstractEnemyDecorator
    {
        public BossEnemyDecorator(AbstractCreature creature) : base(creature)
        {
            Name = $"A very dangerous {creature.Name}";
            HitPoints += 200;
        }
    }
}
