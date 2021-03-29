using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Controller;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Helpers.WorldGenerator;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.WorldClasses;
using System;
using System.Runtime.CompilerServices;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Exceptions;

namespace GameFrameWorkV2.StartUp
{
    public class Game
    {
        public ItemFactory ItemFactory { get; set; }
        public CreatureFactory CreatureFactory { get; set; }
        public World World;
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
            Controller = new Controller(ref World);
            rnd = new Random();
            _draw = new WorldDrawing(World);
        }

        public void SetUpEnemyCreatures(int amountOfEnemies)
        {
            var rndRank = rnd.Next(0, 3);
            string rankString = "";
            if (rndRank == 1) rankString = "boss";
            if (rndRank == 2) rankString = "lieutenant";
            if (rndRank == 3) rankString = "minion";
            var creature = CreatureFactory.CreateEnemyCreature(rankString, null);
            creature.AttackItems.AddAttackItem(ItemFactory.CreateAttackItem("sword","Orchrist",15,1));
            creature.DefencesItems.AddDefenceItem(ItemFactory.CreateDefenceItem("armour", "BreastPlate of Salazar", 10));
            creature.DefencesItems.AddDefenceItem(ItemFactory.CreateDefenceItem("boots", "Boots of Thunder", 2));

            World.WorldPlayGround[creature.Position.X, creature.Position.Y].Creature = creature;
            if (amountOfEnemies - 1 > 0)
            {
                SetUpEnemyCreatures(--amountOfEnemies);
            }
        }


        public void SetUpPlayer(string name, Position? position)
        {
            Player = CreatureFactory.CreatePlayerCreature(name, position);
            Player.AttackItems.AddAttackItem(ItemFactory.CreateAttackItem("sword", "Sting", 50, 1));
            Player.DefencesItems.AddDefenceItem(ItemFactory.CreateDefenceItem("armour", "Mithril Coat", 45));
            Player.DefencesItems.AddDefenceItem(ItemFactory.CreateDefenceItem("boots", "Hairy Hobbit Feet", 5));
            Player.DefencesItems.AddDefenceItem(ItemFactory.CreateDefenceItem("helmet", "Helmet of Gloin", 15));
            World.WorldPlayGround[Player.Position.X, Player.Position.Y].Creature = Player;
        }

        private void RemoveCreaturesOnRestart()
        {
            for (int x = 0; x < World.WorldPlayGround.GetLength(0); x++)
            {
                for (int y = 0; y < World.WorldPlayGround.GetLength(1); y++)
                {
                    if (World.WorldPlayGround[x, y].Creature is EnemyCreature)
                    {
                        World.WorldPlayGround[x, y].Creature = null;
                    }
                }
            }
        }



        public void StartGame(string playerName, Position pos, int amountOfEnemies)
        {
            SetUpPlayer(playerName, pos);
            SetUpEnemyCreatures(amountOfEnemies);
            while (true)
            {
                try
                {
                    Console.WriteLine(_draw.DrawWorld(ref World.WorldPlayGround, ref Player));
                    char directionControl = Console.ReadKey().KeyChar;
                    Controller.PlayerController(Controller.ConvertInput(Convert.ToChar(directionControl)), ref Player);
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(IllegalMoveException))
                    {
                        Console.WriteLine("Illegal move");
                    }
                    else if (e.GetType() == typeof(YouAreDeadException))
                    {
                        Console.Clear();
                        Console.WriteLine("Ohh no you are dead, press a button to restart");
                        Console.ReadKey();
                        RemoveCreaturesOnRestart();
                        StartGame("Bilbo", null, 5);
                    }
                }
            }
        }
    }
}
