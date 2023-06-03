using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IDataBall
    {
        public abstract event EventHandler<DataBallEventArgs> DataBallPositionChanged;
        public static IDataBall CreateBall(float x, float y, int weight, float speedX, float speedY, LoggerAbstract logger)
        {
            return new DataBall(x, y, weight, speedX, speedY, logger);
        }


        // Properties 
        public abstract Vector2 Position { get; }
        public abstract int Weight { get; }
        public abstract Vector2 Velocity { get; set; }
        public abstract void Dispose();
    }
}
