namespace Theatre.UI
{
    using System;
    using Theatre.Contracts;

    public class Renderer : IRenderer
    {
        public void Render(string output)
        {
            Console.WriteLine(output);
        }
    }
}
