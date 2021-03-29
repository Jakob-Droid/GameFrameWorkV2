namespace GameFrameWorkV2.Items.ConcreteItems
{
    public class Shield : DefenceItem
    {
        public Shield(string name, int reduceHitPoints) : base(name, reduceHitPoints)
        {
            Type = "Shield";
        }
    }
}
