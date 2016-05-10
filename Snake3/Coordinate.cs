using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    class Coordinate : ICoordinate
    {


        public int X
        {
            get; set;
        }

        public int Y
        {
            get; set;
        }

        static public Coordinate operator -(Coordinate ob1, Coordinate ob2)
        {
            Coordinate res = new Coordinate();

            res.X = ob1.X - ob2.X;
            res.Y = ob1.Y - ob2.Y;

            return res;
        }
        static public Coordinate operator +(Coordinate ob1, Coordinate ob2)
        {
            Coordinate res = new Coordinate();

            res.X = ob1.X + ob2.X;
            res.Y = ob1.Y + ob2.Y;

            return res;
        }

    }
}
