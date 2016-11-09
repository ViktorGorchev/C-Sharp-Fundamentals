namespace Minesweeper
{
    using Contracts;
    using Engine;
    using UI;

    public class GameMain
    {
        private static void Main()
        {
            IReader reader = new Reader();
            IRenderer renderer = new Renderer();
            
            IEngine engine = new GameEngine(reader, renderer);
            engine.Run();
        }
    }
}
