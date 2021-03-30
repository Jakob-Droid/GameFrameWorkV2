namespace GameFrameWorkV2.Creatures.Decorators
{
    public class MinionEnemyDecorator : AbstractEnemyDecorator
    {
        public MinionEnemyDecorator(AbstractCreature creature) : base(creature)
        {
            Name = $"A feeble {creature.Name}";
            HitPoints -= 5;
        }


    }
}
