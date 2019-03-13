using System;
using System.Collections.Generic;
using System.Drawing;

namespace RobotCleaner.Core
{
    public class Robot
    {
        public HashSet<Point> CleanRooms(Point startingRoomPoint) =>
            CleanRooms(startingRoomPoint, new Queue<CommandRequest>());

        public HashSet<Point> CleanRooms(Point startingRoomPoint, Queue<CommandRequest> commands)
        {
            var cleanedRooms = new HashSet<Point>
            {
                startingRoomPoint
            };
            CommandRequest command;
            var currentRoomPoint = startingRoomPoint;
            while (commands.TryDequeue(out command))
            {
                for (var i = 0; i < command.Step; i++)
                {
                    switch (command.Direction)
                    {
                        case Direction.E:
                            currentRoomPoint.X--;
                            break;
                        case Direction.W:
                            currentRoomPoint.X++;
                            break;
                        case Direction.N:
                            currentRoomPoint.Y++;
                            break;
                        case Direction.S:
                            currentRoomPoint.Y--;
                            break;
                    }
                    currentRoomPoint = new Point(currentRoomPoint.X, currentRoomPoint.Y);
                    cleanedRooms.Add(currentRoomPoint);
                }
            }
            return cleanedRooms;
        }


    }
}