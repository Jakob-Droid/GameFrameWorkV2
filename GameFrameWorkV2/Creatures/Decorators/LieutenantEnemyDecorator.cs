namespace GameFrameWorkV2.Creatures.Decorators
{
    public class LieutenantEnemyDecorator : AbstractEnemyDecorator
    {

        public LieutenantEnemyDecorator(AbstractCreature creature) : base(creature)
        {
            Name = $"An important {creature.Name}";
            HitPoints += 20;
        }
    }
}
