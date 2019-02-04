using System;

namespace ToyRobot
{
    public enum Directions{ north, east, west, south }

    public class Program
    {

        private int X;
        private int Y;
        private Directions directionFacing;
        private string Input { get; set; }

        public Program(string input, int x, int y, Directions directions)
        {
            Input = input.ToUpper().Trim();
            X = x;
            Y = y;
            directionFacing = directions;
        }
       
        public void GamePlay()
        {
            while (true)
            {
                MoveToy(Input);

                Input = Console.ReadLine().ToUpper().Trim();

                if (Input == "REPORT")
                {
                    Console.WriteLine(GetOutput());
                }
            }
        }

        public string GetOutput()
            => $"Output: {X},{Y},{directionFacing.ToString().ToUpper()}";

        public void MoveToy(string input)
        {
            if (input == "MOVE")
            {
                switch (directionFacing)
                {
                    case Directions.north:
                        NorthMovement();
                        break;
                    case Directions.east:
                        EastMovement();
                        break;
                    case Directions.west:
                        WestMovement();
                        break;
                    case Directions.south:
                        SouthMovement();
                        break;
                }
            }

            if (input == "LEFT")
            {
                AdjustDirectionForLeftInput();
            }

            if (input == "RIGHT")
            {
                AdjustDirectionForRightInput();
            }
        }

        private void AdjustDirectionForLeftInput()
        {

            if (directionFacing == Directions.north)
            {
                directionFacing = Directions.west;
            }
            else if (directionFacing == Directions.west)
            {
                directionFacing = Directions.south;
            }
            else if (directionFacing == Directions.south)
            {
                directionFacing = Directions.east;
            }
            else if (directionFacing == Directions.east)
            {
                directionFacing = Directions.north;
            }
        }

        private void AdjustDirectionForRightInput()
        {
            if (directionFacing == Directions.north)
            {
                directionFacing = Directions.east;
            }
            else if (directionFacing == Directions.east)
            {
                directionFacing = Directions.south;
            }
            else if(directionFacing == Directions.south)
            {
                directionFacing = Directions.west;
            }
            else if(directionFacing == Directions.west)
            {
                directionFacing = Directions.north;
            }
        }

        public void NorthMovement()
        {
            if (Y < 4)
            {
                Y++;
            }
        }

        private void SouthMovement()
        {
            if (Y > 0)
            {
                Y--;
            }
        }

        private void EastMovement()
        {
            if (X < 4)
            {
                X++;
            }
        }

        private void WestMovement()
        {
            if (Y > 0)
            {
                X--;
            }
        }

        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var inputArray = input.Split(' ', ',');

            Program p = new Program(inputArray[0],
                                    Convert.ToInt32(inputArray[1]),
                                    Convert.ToInt32(inputArray[2]),
                                    (Directions)Enum.Parse(typeof(Directions),
                                    inputArray[3].ToLower()));
            p.GamePlay();
        }
    }
}
