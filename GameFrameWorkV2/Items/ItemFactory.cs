using GameFrameWorkV2.Items.ConcreteAttackItems;
using GameFrameWorkV2.Items.ConcreteDefenceItems;
using GameFrameWorkV2.Items.ConcreteItems;

namespace GameFrameWorkV2.Items
{
    public class ItemFactory
    {/// <summary>
     /// Creates weapons
     /// </summary>
     /// <param name="itemType">What type of weapon you want, sword or bow</param>
     /// <param name="damage">The damage of the weapon</param>
     /// <param name="name">The name of the weapon</param>
     /// <param name="range">The range of the weapon</param>
     /// <returns></returns>
        public AttackItem CreateAttackItem(string itemType, string name, int damage, int range = 5)
        {
            switch (itemType)
            {
                case "sword":
                    return new Sword(damage, name);
                case "bow":
                    return new Bow(damage, name, range);
                default: return null;
            }
        }
        /// <summary>
        /// Creates armour
        /// </summary>
        /// <param name="itemType">What type of armour you want</param>
        /// <param name="name">The name of the armour</param>
        /// <param name="reduceDamage">The reduced damage of the weapon</param>
        /// <returns></returns>
        public DefenceItem CreateDefenceItem(string itemType, string name, int reduceDamage)
        {
            switch (itemType)
            {
                case "armour":
                    return new Armour(name, reduceDamage);
                case "boots":
                    return new Boots(name, reduceDamage);
                case "helmet":
                    return new Helmet(name, reduceDamage);
                case "shield":
                    return new Shield(name, reduceDamage);
                default: return null;

            }
        }
    }
}
