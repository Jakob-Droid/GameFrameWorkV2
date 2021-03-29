namespace GameFrameWorkV2.Items.ConcreteAttackItems
{
    public class Bow : AttackItem
    {
        public Bow(int damage, string name, int range) : base(damage, name)
        {
            Type = "Bow";
            Range = range;
        }
    }
}
