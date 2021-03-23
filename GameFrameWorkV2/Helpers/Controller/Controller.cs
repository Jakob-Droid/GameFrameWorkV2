using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Helpers.Controller
{
    public class Controller
    {
        private World World;

        public Controller(World world)
        {
            this.World = world;
        }
        public void PlayerController(Input controlInput, PlayerCreature creature, ref World world)
        {
            switch (controlInput)
            {
                case Input.Up:
                if (creature.Position.Y +1 == world.MaxY)
                {
                    throw new Exception("You cannot leave the area");
                }

                creature.Position.Y += 1;
                break;
                case Input.Down:
                    if (creature.Position.Y - 1 == world.MaxY)
                    {
                        throw new Exception("You cannot leave the area");
                    }

                    creature.Position.Y -= 1;
                    break;
                case Input.Right:
                    if (creature.Position.X + 1 == world.MaxX)
                    {
                        throw new Exception("You cannot leave the area");
                    }

                    creature.Position.X += 1;
                    break;
                case Input.Left:
                    if (creature.Position.X - 1 == world.MaxX)
                    {
                        throw new Exception("You cannot leave the area");
                    }

                    creature.Position.X -= 1;
                    break;
            }

            DrawGround(ref world.WorldPlayGround);
        }

        private void DrawGround(ref Tile[,] playGround)
        {
            for (int i = 1; i < playGround.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < playGround.GetLength(1) - 1; j++)
                {
                    playGround[i, j] = new Tile() { Ground = GroundTile.EmptyGround };
                }
            }
        }
    }
}
