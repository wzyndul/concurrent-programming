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
        public static IDataBall CreateBall(int id, float x, float y, float speedX, float speedY, LoggerAbstract logger)
        {
            return new DataBall(id, x, y, speedX, speedY, logger);
        }


        // Properties 
        public abstract int Id {get; }
        public abstract Vector2 Position { get; }
        public abstract Vector2 Velocity { get; set; }
        public abstract void Dispose();
    }
}
