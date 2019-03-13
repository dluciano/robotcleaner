namespace RobotCleaner.Core
{
    public class CommandRequest
    {
        public CommandRequest(Direction direction, int step)
        {
            Direction = direction;
            Step = step;
        }

        public Direction Direction { get; }
        public int Step { get; }
    }
}