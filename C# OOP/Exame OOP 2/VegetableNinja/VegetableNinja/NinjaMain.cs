namespace VegetableNinja
{
    using VegetableNinja.Contracts;
    using VegetableNinja.Core;
    using VegetableNinja.UI;

    public class NinjaMain
    {
        public static void Main()
        {
            IEngine engine = new Engine(new Reader(), new Renderer(), new Factory(), new DataBase());
            engine.Run();
        }
    }
}
