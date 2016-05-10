using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake3
{
    class Snake : TObject

    { 
        
        

        List<Coordinate> coodinates = new List<Coordinate>();
        public Snake(IArea Area, IEnumerable<Coordinate> ListCoordinate, char symbol) : base (Area, symbol)
        {
            coodinates.AddRange(ListCoordinate);
        }

        public override void BiggerSnake()
        {
            Coordinate bigcoor = coodinates.Last();
            coodinates.Add(bigcoor);
        }

        public override IEnumerable<Coordinate> GetCoordinate()
        {
            return coodinates;
        }

        public override void Move()
        {
            List<Coordinate> coor1 = new List<Coordinate>();
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != Directions.Right) direction = Directions.Left;
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (direction != Directions.Left) direction = Directions.Right;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (direction != Directions.Down) direction = Directions.Up;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (direction != Directions.Up) direction = Directions.Down;
                }
            }

            Coordinate delta = new Coordinate { X = 0, Y = 0 };
            switch (direction)
            {
                case (Directions.Up):
                    delta.X = 0; delta.Y = -1;
                    break;
                case (Directions.Down):
                    delta.X = 0; delta.Y = 1;
                    break;
                case (Directions.Left):
                    delta.X = -1; delta.Y = 0;
                    break;
                case (Directions.Right):
                    delta.X = 1; delta.Y = 0;
                    break;
            }


            coor1.Clear();
            coor1.Add(coodinates[0]);
            coor1[0] += delta;
            

            if (coor1[0].X == 0 || coor1[0].Y == 0 || coor1[0].X == Area.Size.X || coor1[0].Y == Area.Size.Y)
            {
                Console.Clear();
                Console.WriteLine("You LOSE!!!!");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }


                foreach (Coordinate data in coodinates)
            {
                coor1.Add(data);
            }
            int a = coor1.Count();
            coor1.RemoveAt(a-1);
            coodinates.Clear();
            coodinates.AddRange(coor1);

        }

        public override void NextRabbit()
        {
            
        }
    }
}
