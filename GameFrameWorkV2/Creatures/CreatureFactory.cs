using System;
using System.Reflection.Metadata.Ecma335;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Creatures.Decorators;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Creatures
{
    public class CreatureFactory
    {
        private readonly World _world;
        private JsonTraceListener _logger;
        Random rnd = new Random();
        public string[] NameArr { get; set; } = new[] { "Orc", "Troll", "Goblin", "Dark Elf" };
        public CreatureFactory(World world, JsonTraceListener logger)
        {
            _logger = logger;
            _world = world;
            _logger.WriteLine("Initializing Creature Factory");
        }
        /// <summary>
        /// Creates a new player
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="pos">The position the player will spawn at</param>
        /// <returns></returns>
        public Creature CreatePlayerCreature(string name, Position? pos)
        {
            GeneratePosition(pos);
            var creature = new PlayerCreature(200, name, pos, _world);
            _logger.WriteLine($"Created Creature {creature}");
            return creature;
        }
        /// <summary>
        /// Creates a new creature
        /// </summary>
        /// <param name="rank"> The rank of your Creature can be boss, lieutenant, defaults to minion </param>
        /// <param name="pos">The position you want your creature to spawn at</param>
        /// <returns></returns>
        public Creature CreateEnemyCreature(string rank, Position? pos)
        {
            Creature creature;
            GeneratePosition(pos);
            EnemyCreature baseCreature = new EnemyCreature(rnd.Next(20, 100), NameArr[rnd.Next(0, NameArr.Length + 1)], pos);
            switch (rank)
            {
                case "boss":
                    creature = new BossEnemyDecorator(baseCreature);
                    _logger.WriteLine($"Created Enemy Creature {creature.Name}");
                    return creature;
                case "lieutenant":
                    creature = new LieutenantEnemyDecorator(baseCreature);
                    _logger.WriteLine($"Created Enemy Creature {creature.Name}");
                    return creature;
                default:
                    creature = new MinionEnemyDecorator(baseCreature);
                    _logger.WriteLine($"Created Enemy Creature {creature.Name}");
                    return creature;
            }
        }

        /// <summary>
        /// This method uses Recursion to generate a new position, if a position is already used it will run again recursively
        /// </summary>
        /// <param name="pos">The position to place a creature at</param>
        /// <returns></returns>
        private Position GeneratePosition(Position? pos)
        {
            var tempPos = pos;
            pos ??= new Position(rnd.Next(0, _world.MaxX), rnd.Next(0, _world.MaxY));
            return (_world.WorldPlayGround[pos.X, pos.Y].Creature is null) ?
                pos : (tempPos is not null) ?
                throw new Exception("The position you selected is already occupied by a creature") :
                GeneratePosition(null);
        }
    }
}
