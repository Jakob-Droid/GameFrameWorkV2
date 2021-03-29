using GameFrameWorkV2.Helpers.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace GameFrameWorkV2.Items.ConcreteAttackItems
{
    public class CompositeAttack : AttackItem
    {
        public CompositeAttack()
        {
            AttackItems = new List<AttackItem>();
        }

        public List<AttackItem> AttackItems { get; set; }

        public override int Damage
        {
            get { return AttackItems.Sum(x => x.Damage); }
        }

        public void AddAttackItem(AttackItem item)
        {
            var items = AttackItems.FindAll(x => x.Type == item.Type);
            if (items.Count < 2 && item.Type == "Sword")
            {
                AttackItems.Add(item);
            }

            else if (items.Count == 0 && item.Type == "Bow")
            {
                AttackItems.Add(item);
            }
            else
            {
                throw new ItemAlreadyEquipped("You cannot equip this item: " + item.Type + " as you already have a maximum of these items equipped");
            }
        }
    }
}
