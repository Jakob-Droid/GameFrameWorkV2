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
        public void PlayerController(Input controlInput, AbstractCreature player, World world)
        {
            switch (controlInput)
            {
                case Input.Up:
                    if (player.Position.X - 1 == world.MaxY - 1)
                    {
                        throw new Exception("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X - 1, player.Position.Y].Creature != null)
                    {
                        player.Hit(World.WorldPlayGround[player.Position.X - 1, player.Position.Y].Creature);
                    }
                    else
                    {
                        player.Position.X -= 1;
                    }
                    
                    break;

                case Input.Down:
                    if (player.Position.X + 1 == world.MaxY - 1)
                    {
                        throw new Exception("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X + 1, player.Position.Y].Creature != null)
                    {
                        player.Hit(World.WorldPlayGround[player.Position.X + 1, player.Position.Y].Creature);
                    }
                    else
                    {
                        player.Position.X += 1;
                    }
                    
                    break;

                case Input.Right:
                    if (player.Position.Y + 1 == world.MaxY - 1)
                    {
                        throw new Exception("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X, player.Position.Y + 1].Creature != null)
                    {
                        player.Hit(World.WorldPlayGround[player.Position.X, player.Position.Y +1].Creature);
                    }
                    else
                    {
                        player.Position.Y += 1;
                    }
                    
                    break;

                case Input.Left:
                    if (player.Position.Y - 1 == world.MaxY - 1)
                    {
                        throw new Exception("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X, player.Position.Y -1].Creature != null)
                    {
                        player.Hit(World.WorldPlayGround[player.Position.X, player.Position.Y -1].Creature);
                    }
                    else
                    {
                        player.Position.Y -= 1;
                    }
                    break;

            }
        }

        public Input ConvertInput(char x)
        {
            switch (x)
            {
                case 'w': return Input.Up;
                case 's': return Input.Down;
                case 'a': return Input.Left;
                case 'd': return Input.Right;
                default: return Input.L;
            }
        }
    }
}
