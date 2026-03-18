// See https://aka.ms/new-console-template for more information
using System;

namespace PingPongApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var settings = GameSettings.Default();
            var game = new Game(settings);
            game.Run();
        }
    }
}

