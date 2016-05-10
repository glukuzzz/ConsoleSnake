using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake3
{
    interface IArea
    {
        ICoordinate Position { get; set; }

        ICoordinate Size { get; set; }

        void Go();

        void RabbitIsDead_LongLiveTheRabbit();

        void Draw();

    }
}
