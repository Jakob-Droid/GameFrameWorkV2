using System;
using GameFrameWorkV2.Creatures.ConcreteCreatures;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.Helpers.WorldGenerator;
using GameFrameWorkV2.StartUp;
using GameFrameWorkV2.WorldClasses;

namespace RpgAdvGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(5, 5);
            game.SetUpPlayer(200, "Bilbo", null);
            game.SetUpEnemyCreatures(5);
            game.StartGame();
            
            
            


        }
        
    }
}
