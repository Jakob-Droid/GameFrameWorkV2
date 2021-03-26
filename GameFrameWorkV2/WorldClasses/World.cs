using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Observer;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.WorldClasses
{
    public class World : IObserver
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        private List<WorldObject> WorldObjects;

        public Tile[,] WorldPlayGround;
        public DeathObserver DeathObserver { get; set; } = new DeathObserver();


        public World(int maxX, int maxY)
        {
            WorldObjects = new List<WorldObject>();
            MaxX = maxX;
            MaxY = maxY;
            WorldPlayGround = new Tile[maxX, maxY];
            DeathObserver.AddObserver(this);
        }

        public void Notify(Creature creature)
        {
            WorldPlayGround[creature.Position.X, creature.Position.Y].Creature = null;
        }
    }
}
