using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Controller;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Helpers.WorldGenerator;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.StartUp
{
    public class Game
    {
        public ItemFactory ItemFactory { get; set; }
        public CreatureFactory CreatureFactory { get; set; }
        public World World { get; set; }
        public JsonTraceListener Logger { get; set; }
        public Controller Controller { get; set; }
        private WorldDrawing _draw;
        public AbstractCreature Player;
        private Random rnd;



        public Game(int worldMaxX, int worldMaxY)
        {
            Logger = new JsonTraceListener();
            World = new World(worldMaxX, worldMaxY);
            ItemFactory = new ItemFactory();
            CreatureFactory = new CreatureFactory(World, Logger);
            Controller = new Controller(World);
            this.rnd = new Random();
        }
        
        public void SetUpEnemyCreatures(int amountOfEnemies)
        {
            var rndRank = rnd.Next(0, 3);
            string rankString = "";
            if (rndRank == 1) rankString = "boss";
            if (rndRank == 2) rankString = "lieutenant";
            if (rndRank == 3) rankString = "minion";
            var creature = CreatureFactory.CreateEnemyCreature(rankString, null);
            World.WorldPlayGround[creature.Position.X, creature.Position.Y].Creature = creature;
            if (amountOfEnemies > 0)
            {
                SetUpEnemyCreatures(--amountOfEnemies);
            }
        }


        public void SetUpPlayer(int hitPoints, string name, Position? position)
        {
            Player = CreatureFactory.CreatePlayerCreature(name, position);
            _draw = new WorldDrawing(World, Player);
        }



        public void StartGame()
        {
            while (true)
            {
                Console.WriteLine(_draw.DrawWorld(ref World.WorldPlayGround));
                Console.ReadLine();

            }
        }





    }
}
