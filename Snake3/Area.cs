using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    class Area : IArea
    {

        


        List<TObject> ObjList = new List<TObject>();

        public Area(Coordinate Position, Coordinate Size)
        {
            this.Position = Position;
            this.Size = Size;
            Coordinate coor = new Coordinate() { X = MyRandom.GenerateRandom(0, Size.X), Y = MyRandom.GenerateRandom(0, Size.Y) };
            Rabbit rabbit = new Rabbit(this, coor, '*');
            ObjList.Add(rabbit);
            Snake snake = new Snake(this, GetSnakeCoordinate(), '&');
            snake.direction = Directions.Up;
            ObjList.Add(snake);
        }


        public ICoordinate Position
        {
            get; set;
        }

        public ICoordinate Size
        {
            get; set;
        }

        public void Draw()
        {
            Console.Clear();
            foreach (TObject snake in ObjList)
            {

                if (snake is Snake)
                {
                    int z = 0;
                    char sym = 'g'; ;
                    if (snake.direction == Directions.Up) { sym = '^'; }
                    else if (snake.direction == Directions.Down) { sym = 'v'; }
                    else if (snake.direction == Directions.Left) { sym = '<'; }
                    else if (snake.direction == Directions.Right) { sym = '>'; }
                    Console.SetCursorPosition(snake.GetCoordinate().ElementAt(z).X, snake.GetCoordinate().ElementAt(z).Y);
                    Console.Write(sym);
                    for (z = 1; ; ++z)
                    {
                        try
                        {
                            Coordinate delta = snake.GetCoordinate().ElementAt(z) - snake.GetCoordinate().ElementAt(z - 1);
                            if (delta.X == 0 && delta.Y == 1) { sym = '^'; }
                            else if (delta.X == 0 && delta.Y == -1) { sym = 'v'; }
                            else if (delta.X == 1 && delta.Y == 0) { sym = '<'; }
                            else if (delta.X == -1 && delta.Y == 0) { sym = '>'; }
                            Console.SetCursorPosition(snake.GetCoordinate().ElementAt(z).X, snake.GetCoordinate().ElementAt(z).Y);
                            Console.Write(sym);
                        }
                        catch { break; }
                    }

                }

                else
                {

                    Console.SetCursorPosition(snake.GetCoordinate().FirstOrDefault().X, snake.GetCoordinate().FirstOrDefault().Y);
                    Console.Write(snake.symbol);
                }


                
            }
        }

        
        void MoveObject()
        {
            foreach(TObject obj in ObjList)
            {
                obj.Move();
            }
        }

        public void Go()
        {
            RabbitIsDead_LongLiveTheRabbit();
            MoveObject();
            Draw();
        }

        public void RabbitIsDead_LongLiveTheRabbit()
        {
            Coordinate rabbit1 = new Coordinate { X = 999, Y = 999 } ;
            Coordinate snake1 = new Coordinate { X = 888, Y = 888 }; 
            foreach(TObject obj in ObjList)
            {
                if(obj is Rabbit) { rabbit1 = obj.GetCoordinate().First(); }
                else { snake1 = obj.GetCoordinate().First(); }
            }
            if (rabbit1.X == snake1.X && rabbit1.Y == snake1.Y) 
            {
                foreach(TObject obj in ObjList)
                {
                    obj.NextRabbit();
                    obj.BiggerSnake();
                }
            }
        }

        IEnumerable<Coordinate> GetSnakeCoordinate()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < 10; ++i)
            {
                Coordinate coor = new Coordinate { X = Size.X / 2, Y = Size.Y/2 + i };
                coordinates.Add(coor);
            }
            return coordinates;
        }
    }
}
