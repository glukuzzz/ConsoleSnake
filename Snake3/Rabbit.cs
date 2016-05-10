using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    class Rabbit : TObject
    {

        Coordinate coordinate;

        

        


        public Rabbit(IArea Area, Coordinate coordinate, char symbol) : base(Area, symbol)
        {
            this.coordinate = coordinate;
            
        }

        

        public override IEnumerable<Coordinate> GetCoordinate()
        {
            List<Coordinate> rabbitcoor = new List<Coordinate>();

            rabbitcoor.Add(coordinate);


            return rabbitcoor;
        }

        public override void NextRabbit()
        {
            coordinate.X = MyRandom.GenerateRandom(0, Area.Size.X);
            coordinate.Y = MyRandom.GenerateRandom(0, Area.Size.Y);
        }

        public override void Move()
        {
            
        }

        

        public override void BiggerSnake()
        {
            
        }
    }
}
