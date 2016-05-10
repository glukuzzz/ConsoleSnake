using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    abstract class TObject 
    {
        public  Directions direction { get;  set; }
       protected IArea Area { get; private set; }
        public char symbol { get; private set; }

        public TObject(IArea Area, char symbol)
        {
            this.Area = Area;
            this.symbol = symbol;
        }

        
        public abstract IEnumerable<Coordinate> GetCoordinate();
        public abstract void Move();

        public abstract void NextRabbit();
        public abstract void BiggerSnake();

    }
}
