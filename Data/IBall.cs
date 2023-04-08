using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IBall
    {
        public abstract void MoveBall();
        public static IBall CreateBall(int x, int y, int speedX = 0, int speedY = 0)
        {
            return new Ball(x, y, speedX, speedY);
        }
        public abstract (int, int) GetBallPosition();
        public abstract (int, int) GetBallSpeed();
        public abstract int GetBallRadius();
    }
}
