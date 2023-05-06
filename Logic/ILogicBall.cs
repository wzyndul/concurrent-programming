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
        public static ILogicBall CreateBall(int x, int y, int radius, int speedX = 0, int speedY = 0)
        {
            return new LogicBall(x, y, radius, speedX, speedY);
        }
        public abstract int XPosition { get; set; }
        public abstract int YPosition { get; set; }
        public abstract int Radius { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract void UpdateBall(Object source, PropertyChangedEventArgs e);
    }
}
