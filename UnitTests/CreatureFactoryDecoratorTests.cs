using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Exceptions;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.WorldClasses;
using Xunit;

namespace UnitTests
{
    public class CreatureFactoryDecoratorTests
    {
        private CreatureFactory _factory;
        private World _world;
        private World _world2;
        private JsonTraceListener _logger;

        public CreatureFactoryDecoratorTests()
        {
            _world = new World(10, 10);
            _world2 = new World(10, 10);
            _logger = new JsonTraceListener("UnitTestLog.json");
            _factory = new CreatureFactory(_world, _logger);
        }

        //Test That makes sure that an exception is thrown when you position a playerCreature ontop of another
        [Fact]
        public void Test_Initializing_Of_Player_With_Same_Position()
        {
            var creat = _factory.CreatePlayerCreature("Jens", new Position(5, 5));
            _world.WorldPlayGround[creat.Position.X, creat.Position.Y].Creature = creat;

            Assert.Throws<PositionAlreadyOccupiedException>(() =>
            {
                creat = _factory.CreatePlayerCreature("Jens", new Position(5, 5));
                _world.WorldPlayGround[creat.Position.X, creat.Position.Y].Creature = creat;
            });
        }

        //Test That makes sure that an exception is thrown when you position an EnemyCreature ontop of another
        [Fact]
        public void Test_Initializing_Of_Creature_With_Same_Position()
        {
            var creat = _factory.CreateEnemyCreature("boss", new Position(5, 5));
            _world.WorldPlayGround[creat.Position.X, creat.Position.Y].Creature = creat;

            Assert.Throws<PositionAlreadyOccupiedException>(() =>
            {
                creat = _factory.CreateEnemyCreature("Lieutenant", new Position(5, 5));
                _world.WorldPlayGround[creat.Position.X, creat.Position.Y].Creature = creat;
            });
        }
    }
}
