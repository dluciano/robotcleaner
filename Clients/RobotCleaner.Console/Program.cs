using System;
using System.Collections.Generic;
using System.Drawing;
using RobotCleaner.Core;

namespace RobotCleaner.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var commandCountText = Console.ReadLine();
            var commandsCount = int.Parse(commandCountText);

            var startPointText = Console.ReadLine()?.Split(' ');
            var startX = int.Parse(startPointText[0]);
            var startY = int.Parse(startPointText[1]);
            var starPoint = new Point(startX, startY);

            var commands = new Queue<CommandRequest>();
            for (var i = 0; i < commandsCount; i++)
            {
                var commandText = Console.ReadLine()?.Split(' ');

                var direction = Enum.Parse<Direction>(commandText[0], true);
                var step = int.Parse(commandText[1]);
                var command = new CommandRequest(direction, step);
                commands.Enqueue(command);
            }

            var cleanedCount = new Robot().CleanRooms(starPoint, commands);
            Console.Write($"=> Cleaned: {cleanedCount}");
            Console.Read();
        }
    }
}
