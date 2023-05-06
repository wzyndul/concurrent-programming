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
        public static IDataBall CreateBall(double x, double y, double radius, int weight, double speedX = 0.0, double speedY = 0.0)
        {
            return new DataBall(x, y, radius, weight, speedX, speedY);
        }

        public abstract bool CheckBorderColision(int width, int height);

        // Properties needed for ModelBall
        public abstract double XPosition { get; set; }
        public abstract double YPosition { get; set; }
        public abstract double Radius { get; set; }
        public abstract double XSpeed { get; set; }
        public abstract double YSpeed { get; set; }
        public abstract void OppositeXSpeed();
        public abstract void OppositeYSpeed();

        public abstract int Weight { get;}
        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }
}
