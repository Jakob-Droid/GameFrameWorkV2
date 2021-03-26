using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Exceptions;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items.ConcreteAttackItems;
using GameFrameWorkV2.WorldClasses;
using Xunit;

namespace UnitTests
{
    public class CreatureAttackTests
    {
        private CreatureFactory _crtFactory;
        private Creature _enemy;
        private PlayerCreature _player;
        private World _world;
        private JsonTraceListener _logger;
        public CreatureAttackTests()
        {
            _logger = new JsonTraceListener();
            _world = new World(5,5);
            _crtFactory = new CreatureFactory(_world, _logger);
            _enemy = _crtFactory.CreateEnemyCreature("boss", new Position(1, 1));
            _player = _crtFactory.CreatePlayerCreature("Bilbo", new Position(2,1)) as PlayerCreature;
            _player.AttackItems.AddAttackItem(new Sword(40, "Sting"));
            _player.AttackItems.AddAttackItem(new Sword(40, "Sting"));

        }

        [Fact]
        public void Creature_Attack_Another_Creature()
        {
            var enmhp = _enemy.HitPoints;
            var dmg = _player.AttackItems.Damage + _player.Strength;
            _player.Hit(_enemy);
            Assert.Equal(enmhp-dmg, _enemy.HitPoints);

        }

        [Fact]
        public void Player_Try_Equip_Three_Weapon()
        {
            Assert.Throws<ItemAlreadyEquipped>(()=>_player.AttackItems.AddAttackItem(new Sword(40, "Sting")));
        }
    }
}
