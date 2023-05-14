using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public abstract class ILogicBall
    {
        public static ILogicBall CreateBall(double x, double y)
        {
            return new LogicBall(x, y);
        }
        public abstract double XPosition { get; set; }
        public abstract double YPosition { get; set; }

        public abstract event EventHandler<LogicBallEventArgs> LogicBallPositionChanged;
        public abstract void UpdateBall(Object source, DataBallEventArgs e);
    }
}
