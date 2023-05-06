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
        public abstract void MoveBall();
        public static IDataBall CreateBall(int x, int y, int radius, int speedX = 0, int speedY = 0)
        {
            return new DataBall(x, y, radius, speedX, speedY);
        }
        public abstract void ChangeSpeed(int x, int y);

        public abstract bool CheckBorderColision(int width, int height);

        // Properties needed for ModelBall
        public abstract int XPosition { get; set; }
        public abstract int YPosition { get; set; }
        public abstract int Radius { get; set; }
        public abstract int XSpeed { get; }
        public abstract int YSpeed { get; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }
}
