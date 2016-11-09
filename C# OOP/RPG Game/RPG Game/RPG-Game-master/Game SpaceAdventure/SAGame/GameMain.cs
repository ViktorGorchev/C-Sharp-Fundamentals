
using System;
using SAGame.Core.Engine;
using SAGame.Enums;

namespace SAGame
{
    using Models.Battleships;
    using Interfaces;
    using Items;
    using Items.Weapons;
    using UI;

    public class GameMain
    {

        public static void Main()
        {
            IInputReader reader = new InputReader();
            IRenderer renderer = new Renderer();
            
            //IPlayer player = new Starfighter();
            //SeedInitialPlayerInventory(player);

            IEngine engine = new GameEngine(reader, renderer);
            engine.Run();
        }

        //private static void SeedInitialPlayerInventory(IPlayer player)
        //{
        //    Position defaultPosition = new Position(0, 0);


        //    ICollectible weapon = new RegularDC17(defaultPosition);
        //    weapon.State = ItemState.Collected;
        //    player.AddItemToInventory(weapon);
        //}


    }
}
