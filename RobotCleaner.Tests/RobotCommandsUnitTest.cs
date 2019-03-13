using System.Collections.Generic;
using System.Drawing;
using RobotCleaner.Core;
using Shouldly;
using Xunit;

namespace RobotCleaner.Tests
{
    public class RobotCommandsUnitTest
    {
        [Fact]
        public void When_no_commands_sent_then_one_room_should_be_cleaned()
        {
            var robot = new Robot();
            var startingPoint = new Point(0, 0);
            var roomsCleaned = robot.CleanRooms(startingPoint);
            roomsCleaned.ShouldBe(1);
        }

        [Fact]
        public void When_execute_command_1_step_to_any_direction_then_two_rooms_should_be_cleaned()
        {
            var robot = new Robot();
            var commands = new Queue<CommandRequest>();
            commands.Enqueue(new CommandRequest(Direction.N, 1));
            var startingPoint = new Point(0, 0);
            var roomsCleaned = robot.CleanRooms(startingPoint, commands);
            roomsCleaned.ShouldBe(2);
        }
    }
}
