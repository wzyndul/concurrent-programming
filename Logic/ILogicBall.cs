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
        public static ILogicBall CreateBall(double x, double y, int weight, double speedX = 0, double speedY = 0)
        {
            return new LogicBall(x, y, weight, speedX, speedY);
        }
        public abstract double XPosition { get; set; }
        public abstract double YPosition { get; set; }
        //public abstract double Radius { get; set; }
        public abstract double XSpeed { get; set; }
        public abstract double YSpeed { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract void UpdateBall(Object source, PropertyChangedEventArgs e);
    }
}
