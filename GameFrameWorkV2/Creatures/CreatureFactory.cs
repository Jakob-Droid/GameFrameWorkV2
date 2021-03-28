#nullable enable
using System;
using System.Reflection.Metadata.Ecma335;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Creatures.Decorators;
using GameFrameWorkV2.Helpers.Exceptions;
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
        public string[] NameArr { get; set; } = new[] { "Orc", "Troll", "Enemy", "Dark Elf" };

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
        public AbstractCreature CreatePlayerCreature(string name, Position? pos)
        {
            try
            {
                pos = GeneratePosition(pos);
            }
            catch (PositionAlreadyOccupiedException e)
            {
                _logger.WriteLine("Failed to create PlayerCreature on specified position Error:");
                _logger.WriteLine(e);
                //CreatePlayerCreature(name, null);
                throw e;
            }
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
        public AbstractCreature CreateEnemyCreature(string rank, Position? pos)
        {
            try
            {
                AbstractCreature creature;
                pos = GeneratePosition(pos);
                EnemyCreature baseCreature = new EnemyCreature(rnd.Next(20, 100), NameArr[rnd.Next(0, NameArr.Length)], pos);
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
            catch (PositionAlreadyOccupiedException e)
            {
                _logger.WriteLine("Failed to create EnemyCreature on specified position Error:");
                _logger.WriteLine(e);
                //CreateEnemyCreature(rank, null);
                throw e;
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
            pos ??= new Position(rnd.Next(1, _world.MaxX - 1), rnd.Next(1, _world.MaxY - 1));
            return (_world.WorldPlayGround[pos.X, pos.Y].Creature == null)
                ? pos
                : (tempPos != null)
                    ? throw new PositionAlreadyOccupiedException("The position you selected is already occupied by a creature")
                    : GeneratePosition(null);
        }
    }
}
