using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataBall : IDataBall, INotifyPropertyChanged
    {
        private int _xPosition { get; set; }
        private int _yPosition { get; set; }
        private int _xSpeed { get; set; }
        private int _ySpeed { get; set; }
        private int _radius { get; set; }

        internal DataBall(int xPosition, int yPosition, int radius, int xSpeed = 0, int ySpeed = 0)
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

        public override int XSpeed
        {
            get => _xSpeed;
        }

        public override int YSpeed
        {
            get => _ySpeed;
        }

        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool CheckBorderColision(int width, int height)
        {
            if (_xPosition + _xSpeed + _radius >= width || _yPosition + _ySpeed + _radius >= height
                || _xPosition + -_radius * 2 + _xSpeed <= 0 || _yPosition - _radius * 2 + _ySpeed <= 0) { return false; }
            return true;
        }
    }
}
