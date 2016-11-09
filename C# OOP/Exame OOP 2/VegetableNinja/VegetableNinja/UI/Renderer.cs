namespace VegetableNinja.UI
{
    using System;

    using VegetableNinja.Contracts;

    public class Renderer : IRenderer
    {
        public void Render(string output)
        {
            Console.WriteLine(output);
        }
    }
}
