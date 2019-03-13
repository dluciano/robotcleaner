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

        [Theory]
        [MemberData(nameof(MovingOneStepAnyDirectionData))]
        public void When_moving_1_step_to_any_direction_then_two_rooms_should_be_cleaned(CommandRequest command)
        {
            var robot = new Robot();
            var commands = new Queue<CommandRequest>();
            commands.Enqueue(command);
            var startingPoint = new Point(0, 0);
            var roomsCleaned = robot.CleanRooms(startingPoint, commands);
            roomsCleaned.ShouldBe(2);
        }

        [Fact]
        public void When_moving_1_step_to_N_and_1_to_E_then_three_rooms_should_be_cleaned()
        {
            var robot = new Robot();
            var commands = new Queue<CommandRequest>();
            commands.Enqueue(new CommandRequest(Direction.N, 1));
            commands.Enqueue(new CommandRequest(Direction.E, 1));
            var startingPoint = new Point(0, 0);

            var roomsCleaned = robot.CleanRooms(startingPoint, commands);
            roomsCleaned.ShouldBe(3);
        }

        [Fact]
        public void When_moving_2_step_to_N__1_to_S_and_1_to_E_then_three_rooms_should_be_cleaned()
        {
            var robot = new Robot();
            var commands = new Queue<CommandRequest>();
            commands.Enqueue(new CommandRequest(Direction.N, 2));
            commands.Enqueue(new CommandRequest(Direction.E, 1));
            var startingPoint = new Point(0, 0);

            var roomsCleaned = robot.CleanRooms(startingPoint, commands);
            roomsCleaned.ShouldBe(3);
        }

        [Fact]
        public void When_moving_2_E_and_1_N_then_4_rooms_should_be_cleaned()
        {
            var robot = new Robot();
            var commands = new Queue<CommandRequest>();
            commands.Enqueue(new CommandRequest(Direction.E, 2));
            commands.Enqueue(new CommandRequest(Direction.N, 1));
            var startingPoint = new Point(10, 22);

            var roomsCleaned = robot.CleanRooms(startingPoint, commands);
            roomsCleaned.ShouldBe(3);
        }

        public static TheoryData<CommandRequest> MovingOneStepAnyDirectionData =>
            new TheoryData<CommandRequest>
            {
                new CommandRequest(Direction.N, 1),
                new CommandRequest(Direction.S, 1),
                new CommandRequest(Direction.E, 1),
                new CommandRequest(Direction.W, 1)
            };
    }
}
