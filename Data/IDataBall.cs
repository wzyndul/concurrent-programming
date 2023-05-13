using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IDataBall
    {
        public abstract event EventHandler<DataBallEventArgs> DataBallPositionChanged;
        public static IDataBall CreateBall(double x, double y, int weight, double speedX = 0.0, double speedY = 0.0)
        {
            return new DataBall(x, y, weight, speedX, speedY);
        }

        public abstract void StopMoving();

        // Properties 
        public abstract double XPosition { get; set; }
        public abstract double YPosition { get; set; }
        public abstract int Weight { get; }
        //public abstract double Radius { get; set; }
        public abstract double XSpeed { get; set; }
        public abstract double YSpeed { get; set; }

        
    }
}
