using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.WorldClasses;
using System;
using GameFrameWorkV2.Helpers.Exceptions;
using GameFrameWorkV2.Helpers.Structs;

namespace GameFrameWorkV2.Helpers.Controller
{
    public class Controller
    {
        private World World;

        public Controller(ref World world)
        {
            this.World = world;
        }
        public void PlayerController(Input controlInput, ref AbstractCreature player)
        {
            switch (controlInput)
            {
                case Input.Up:
                    if (player.Position.X - 1 == 0)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X - 1, player.Position.Y].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X - 1, player.Position.Y].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        player.Position.X -= 1;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = play;
                    }

                    break;

                case Input.Down:
                    if (player.Position.X + 1 == World.MaxX - 1)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X + 1, player.Position.Y].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X + 1, player.Position.Y].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        player.Position.X += 1;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = play;
                    }

                    break;

                case Input.Right:
                    if (player.Position.Y + 1 == World.MaxY - 1)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X, player.Position.Y + 1].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X, player.Position.Y + 1].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        player.Position.Y += 1;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = play;
                    }

                    break;

                case Input.Left:
                    if (player.Position.Y - 1 == 0)
                    {
                        throw new IllegalMoveException("You cannot leave the area");
                    }
                    else if (World.WorldPlayGround[player.Position.X, player.Position.Y - 1].Creature != null)
                    {
                        var creature = World.WorldPlayGround[player.Position.X, player.Position.Y - 1].Creature;
                        player.Hit(creature);
                        creature?.Hit(player);
                    }
                    else
                    {
                        var play = World.WorldPlayGround[player.Position.X, player.Position.Y].Creature;
                        World.WorldPlayGround[player.Position.X, player.Position.Y].Creature = null;
                        play.Position.Y -= 1;
                        World.WorldPlayGround[play.Position.X, play.Position.Y].Creature = play;

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
