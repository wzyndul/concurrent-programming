using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ball : IBall
    {
        private int _xPosition { get; set; }
        private int _yPosition { get; set; }
        private int _xSpeed { get; set; }
        private int _ySpeed { get; set; }
        private int _radius { get; set; }

        public Ball(int xPosition, int yPosition, int radius, int xSpeed = 0, int ySpeed = 0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _radius = radius;
        }

        public override void MoveBall()
        {
            this._xPosition += _xSpeed;
            this._yPosition += _ySpeed;
        }

        public override (int, int) GetBallPosition()
        {
            return (this._xPosition, this._yPosition);
        }
        public override (int, int) GetBallSpeed()
        {
            return (this._xSpeed, this._ySpeed);
        }
        public override int GetBallRadius()
        {
            return this._radius;
        }
    }
}
