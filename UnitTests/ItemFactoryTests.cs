using GameFrameWorkV2.Items;
using Xunit;

namespace UnitTests
{
    public class ItemFactoryTests
    {
        private ItemFactory _factory;

        public ItemFactoryTests()
        {
            _factory = new ItemFactory();

        }

        [Fact]
        public void Test_Initializing_Defence_Items()
        {
            DefenceItem breastPlate = _factory.CreateDefenceItem("armour", "Mithril Breast Plate", 20);
            Assert.Equal("Mithril Breast Plate", breastPlate.Name);
            Assert.Equal(20, breastPlate.ReduceHitPoints);
            Assert.Equal("Armour", breastPlate.Type);
        }

        [Fact]
        public void Test_Initializing_SwordAttack_Items()
        {
            AttackItem attackItem = _factory.CreateAttackItem("sword", "Sting", 40);
            Assert.Equal("Sting", attackItem.Name);
            Assert.Equal(40, attackItem.Damage);
            Assert.Equal("Sword", attackItem.Type);
            Assert.Equal(1, attackItem.Range);
        }
        [Fact]
        public void Test_Initializing_BowAttack_Items()
        {
            AttackItem attackItem = _factory.CreateAttackItem("bow", "Bow", 20, 10);
            Assert.Equal("Bow", attackItem.Name);
            Assert.Equal(20, attackItem.Damage);
            Assert.Equal("Bow", attackItem.Type);
            Assert.Equal(10, attackItem.Range);
        }
    }
}
