namespace GameFrameWorkV2.Items.ConcreteDefenceItems
{
    public class Helmet : DefenceItem
    {
        public Helmet(string name, int reduceHitPoints) : base(name, reduceHitPoints)
        {
            Type = "Helmet";
        }
    }
}
