using System;
using System.Collections.Generic;
using System.Drawing;

namespace RobotCleaner.Core
{
    public class Robot
    {
        public int CleanRooms(Point startingPoint)
        {
            var cleanedPoints = new HashSet<Point>()
            {
                startingPoint
            };
            return cleanedPoints.Count;
        }

        public int CleanRooms(Point startingPoint, Queue<CommandRequest> commands)
        {
            throw new NotImplementedException();
        }
    }
}