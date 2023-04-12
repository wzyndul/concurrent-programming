using System;
using System.Collections.Generic;
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
            return new Ball(x, y, radius,speedX, speedY);
        }
        public abstract (int, int) GetBallPosition();
        public abstract (int, int) GetBallSpeed();
        public abstract int GetBallRadius();
    }
}
