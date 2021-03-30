using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Exceptions;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.Items.ConcreteAttackItems;
using GameFrameWorkV2.WorldClasses;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;

namespace UnitTests
{
    public class CreatureAttackTests
    {
        private CreatureFactory _crtFactory;
        private ItemFactory _itmFactory;
        private EnemyCreature _enemy;
        private PlayerCreature _player;
        private World _world;
        private JsonTraceListener _logger;
        public CreatureAttackTests()
        {
            _logger = new JsonTraceListener();
            _world = new World(5, 5);
            _crtFactory = new CreatureFactory(_world, _logger);
            _itmFactory = new ItemFactory();
            _enemy = _crtFactory.CreateEnemyCreature("boss", new Position(1, 1)) as EnemyCreature;
            _player = _crtFactory.CreatePlayerCreature("Bilbo", new Position(2, 1)) as PlayerCreature;
            _world.WorldPlayGround[_enemy.Position.X, _enemy.Position.Y].Creature = _enemy;
            _world.WorldPlayGround[_player.Position.X, _player.Position.Y].Creature = _player;
            _player.AttackItems.AddAttackItem(new Sword(40, "Sting"));
            _player.AttackItems.AddAttackItem(new Sword(40, "Sting"));

        }

        [Fact]
        public void Creature_Attack_Another_Creature()
        {
            var enmhp = _enemy.HitPoints;
            var dmg = _player.AttackItems.Damage + _player.Strength;
            _player.Hit(_enemy);
            Assert.Equal(enmhp - dmg, _enemy.HitPoints);

        }

        [Fact]
        public void Player_Try_Equip_Valid_Item()
        {
            var item = _itmFactory.CreateDefenceItem("boots", "Booties", 5);
            _player.LootItemOnGround(item);
            Assert.NotNull(_player.DefencesItems.DefenceItems.Find(x=>x.Name == "Booties"));
        }

        [Fact]
        public void Player_Try_To_Loot_From_The_Ground()
        {
            _world.WorldPlayGround[_player.Position.X, _player.Position.Y].Object = new List<IWorldObject>();
            _world.WorldPlayGround[_player.Position.X, _player.Position.Y].Object.Add(_itmFactory.CreateDefenceItem("armour", "Mithril Coat", 5));
            _player.Loot(_world, "Mithril Coat");
            Assert.NotNull(_player.DefencesItems.DefenceItems.Find(x=>x.Name == "Mithril Coat"));
        }
        [Fact]
        public void Player_Try_Equip_Three_Weapon()
        {
            //we've already equipped two sword in the constructor
            //This is the third, and "Bilbo" only have two hands, so he cannot carry two swords
            Assert.Throws<ItemAlreadyEquipped>(() => _player.AttackItems.AddAttackItem(new Sword(40, "Sting")));
        }

        [Fact]
        public void Test_Creature_Is_Killed()
        {
            _enemy.HitPoints = 10;
            _player.Hit(_enemy);
            Assert.Null(_world.WorldPlayGround[_enemy.Position.X, _enemy.Position.Y].Creature);
        }

        [Fact]
        public void Test_Creature_Defence_Items_Negates_Damage()
        {
            _enemy.DefencesItems.AddDefenceItem(_itmFactory.CreateDefenceItem("boots", "Boots of Swiftness", 20));

            var dmg = _player.AttackItems.Damage + _player.Strength;
            var enemyItemsReduceHitPoints = _enemy.DefencesItems.ReduceHitPoints;
            var testedHpLeft = _enemy.HitPoints - (dmg - enemyItemsReduceHitPoints);

            _player.Hit(_enemy);

            Assert.Equal(_enemy.HitPoints, testedHpLeft);
        }

        [Fact]
        public void Test_Creature_Drops_Inventory_Upon_Death()
        {
            var sword = _itmFactory.CreateAttackItem("sword", "Orchrist", 60, 1);
            var helmet = _itmFactory.CreateDefenceItem("helmet", "Gimli's helmet", 20);
            _enemy.AttackItems.AddAttackItem(sword);
            _enemy.DefencesItems.AddDefenceItem(helmet);
            _enemy.HitPoints = 5;
            _player.Hit(_enemy);

            var expectedItemsOnGround = new List<IItem>
            {
                sword,
                helmet,
            };

            Assert.Equal(expectedItemsOnGround, _world.WorldPlayGround[_enemy.Position.X, _enemy.Position.Y].Object);
        }
    }
}
