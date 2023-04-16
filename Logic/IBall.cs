using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class IBall
    {
        public abstract void MoveBall();
        public static IBall CreateBall(int x, int y, int radius, int speedX = 0, int speedY = 0)
        {
            return new Ball(x, y, radius, speedX, speedY);
        }
        public abstract void ChangeSpeed(int x, int y);


        // Properties needed for ModelBall
        public abstract int XPosition { get; set; }
        public abstract int YPosition { get; set; }
        public abstract int Radius { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }
}
