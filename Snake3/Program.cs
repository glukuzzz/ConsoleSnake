using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake3
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate pos = new Coordinate { X = 0, Y = 0 };
            Coordinate size = new Coordinate { X = 50, Y = 50 };
            Area area = new Area(pos, size);

            Console.SetWindowSize(area.Size.X, area.Size.Y);
            Console.CursorVisible = false;

            while(true)
            {
                
                area.Go();
                Thread.Sleep(100);
            }


            
        }
    }
}
