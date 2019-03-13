using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

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
                for (var i = 0; i < command.Step; i++)
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
                    currentPoint = new Point(currentPoint.X, currentPoint.Y);
                    cleanedPoints.Add(currentPoint);
                }
            }
            return cleanedPoints.Count;
        }


    }
}