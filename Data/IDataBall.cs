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
        public static IDataBall CreateBall(float x, float y, int weight, float speedX, float speedY)
        {
            return new DataBall(x, y, weight, speedX, speedY);
        }


        // Properties 
        public abstract Vector2 Position { get; set; }
        public abstract int Weight { get; }
        public abstract float XSpeed { get; set; }
        public abstract float YSpeed { get; set; }

        
    }
}
