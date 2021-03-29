using System;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Observer;
using GameFrameWorkV2.Helpers.Structs;
using System.Collections.Generic;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Exceptions;

namespace GameFrameWorkV2.WorldClasses
{
    public class World : IObserver
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        private List<IWorldObject> WorldObjects;


        public Tile[,] WorldPlayGround;
        public DeathObserver DeathObserver { get; set; } = new DeathObserver();


        public World(int maxX, int maxY)
        {
            WorldObjects = new List<IWorldObject>();
            MaxX = maxX;
            MaxY = maxY;
            WorldPlayGround = new Tile[maxX, maxY];
            DeathObserver.AddObserver(this);
        }

        public void Notify(AbstractCreature creature)
        {
            //dropping items upon death
            var droppedItems = creature.OnDeath();
            if (droppedItems != null && WorldPlayGround[creature.Position.X, creature.Position.Y].Object == null)
            {
                WorldPlayGround[creature.Position.X, creature.Position.Y].Object = new List<IWorldObject>() { };
                WorldPlayGround[creature.Position.X, creature.Position.Y].Object.AddRange(droppedItems);
            }
            //else if(droppedItems != null)
            //{
            //    WorldPlayGround[creature.Position.X, creature.Position.Y].Object.AddRange(droppedItems);                                                               
            //}
            //Destroys the creature
            if (creature.GetType() == typeof(PlayerCreature))
            {
                throw new YouAreDeadException("The player has died");
            }
            WorldPlayGround[creature.Position.X, creature.Position.Y].Creature = null;
        }
    }
}
