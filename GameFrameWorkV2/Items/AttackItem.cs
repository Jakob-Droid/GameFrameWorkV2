using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Items
{
    public abstract class AttackItem : IItem
    {
        public virtual int Damage { get; set; }
        public Position Position { get; set; }
        public bool IsLootable { get; set; } = true;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Range { get; set; }

        protected AttackItem(int damage, string name)
        {
            Damage = damage;
            Name = name;
        }

        public AttackItem()
        {

        }
    }
}
