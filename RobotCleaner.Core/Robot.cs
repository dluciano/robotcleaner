using System;
using System.Collections.Generic;
using System.Drawing;

namespace RobotCleaner.Core
{
    public class Robot
    {
        public int CleanRooms(Point startingPoint) =>
            CleanRooms(startingPoint, new Queue<CommandRequest>());

        public int CleanRooms(Point startingPoint, Queue<CommandRequest> commands)
        {
            var cleanedPoints = new HashSet<Point>
            {
                startingPoint
            };
            CommandRequest command;
            var currentPoint = startingPoint;
            while (commands.TryDequeue(out command))
            {
                currentPoint = Move(command, currentPoint);
                cleanedPoints.Add(currentPoint);
            }
            return cleanedPoints.Count;
        }

        private Point Move(CommandRequest command, Point currentPoint)
        {
            switch (command.Direction)
            {
                case Direction.E:
                    currentPoint.X--;
                    break;
                case Direction.W:
                    currentPoint.X++;
                    break;
                case Direction.N:
                    currentPoint.Y++;
                    break;
                case Direction.S:
                    currentPoint.Y--;
                    break;
            }

            return new Point(currentPoint.X, currentPoint.Y);
        }
    }
}