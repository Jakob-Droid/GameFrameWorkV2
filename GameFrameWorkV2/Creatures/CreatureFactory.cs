using System;
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
        public string[] NameArr { get; set; } = new[] {"Orc", "Troll", "Goblin", "Dark Elf"};
        public CreatureFactory(World world, JsonTraceListener logger)
        {
            _logger = logger;
            _world = world;
            _logger.WriteLine("Initializing Creature Factory");
        }
        public Creature CreatePlayerCreature(string name, Position? pos)
        {
            pos ??= new Position(rnd.Next(0, _world.MaxX), rnd.Next(0, _world.MaxY));
            var creature = new PlayerCreature(200, name, pos, _world);
            _logger.WriteLine($"Created Creature {creature}");
            return creature;
        }
        public Creature CreateEnemyCreature(string rank, Position? pos)
        {
            //TODO - Hvad nu hvis der allerede er et creature på et bestemt punkt??
            pos ??= new Position(rnd.Next(0, _world.MaxX), rnd.Next(0, _world.MaxY));
            Creature creature;
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
    }
}
