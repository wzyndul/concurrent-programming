using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        private int _xPosition { get; set; }
        private int _yPosition { get; set; }
        private int _xSpeed { get; set; }
        private int _ySpeed { get; set; }
        private int _radius { get; set; }

        internal Ball(int xPosition, int yPosition, int radius, int xSpeed = 0, int ySpeed = 0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _radius = radius;
        }



        public override void MoveBall()
        {
            this.XPosition += _xSpeed;
            this.YPosition += _ySpeed;
        }


        public override void ChangeSpeed(int x, int y)
        {
            this._xSpeed = x; this._ySpeed = y;
        }
        public override int GetXPosition()
        {
            return this._xPosition;
        }
        public override int GetYPosition()
        {
            return this._yPosition;
        }
        public override int GetRadius() 
        {
            return this._radius;
        }

        // Properties needed for ModelBall
        public override int XPosition
        {
            get => _xPosition;
            set
            {
                _xPosition = value;
                RaisePropertyChanged();
            }
        }

        public override int YPosition
        {
            get => _yPosition;
            set
            {
                _yPosition = value;
                RaisePropertyChanged();
            }
        }
        public override int Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                RaisePropertyChanged();
            }
        }


        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
