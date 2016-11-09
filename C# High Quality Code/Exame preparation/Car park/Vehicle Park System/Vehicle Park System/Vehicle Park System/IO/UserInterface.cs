namespace Vehicle_Park_System.IO
{
    using System;

    using Vehicle_Park_System.Contracts;

    public class UserInterface : IUserInterface
    {
        public string ReadLine()
        {
            var inputLine = Console.ReadLine();

            return inputLine;
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format, args); 
        }
    }
}
