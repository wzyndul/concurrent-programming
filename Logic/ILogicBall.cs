using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public abstract class ILogicBall
    {
        public static ILogicBall CreateBall(float x, float y)
        {
            return new LogicBall(x, y);
        }
        public abstract Vector2 Position { get; set; }

        public abstract event EventHandler<LogicBallEventArgs> LogicBallPositionChanged;
        public abstract void UpdateBall(Object source, DataBallEventArgs e);
    }
}
