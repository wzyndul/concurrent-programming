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
        private double _xPosition { get; set; }
        private double _yPosition { get; set; }
        private double _xSpeed { get; set; }
        private double _ySpeed { get; set; }
        private double _radius { get; set; }
        private int _weight { get; set; }

        internal DataBall(double xPosition, double yPosition, double radius, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _radius = radius;
            _weight = weight;
        }



        public override void MoveBall()
        {
            this.XPosition += _xSpeed;
            this.YPosition += _ySpeed;
        }



        // Properties needed for ModelBall
        public override double XPosition
        {
            get => _xPosition;
            set
            {
                _xPosition = value;
                RaisePropertyChanged();
            }
        }

        public override double YPosition
        {
            get => _yPosition;
            set
            {
                _yPosition = value;
                RaisePropertyChanged();
            }
        }
        public override double Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                RaisePropertyChanged();
            }
        }

        public override double XSpeed
        {
            get => _xSpeed;
            set {
                _xSpeed = value; RaisePropertyChanged();
            }
        }

        public override double YSpeed
        {
            get => _ySpeed;
            set
            {
                _ySpeed = value; RaisePropertyChanged();
            }
        }
        public override int Weight
        {
            get => _weight;
        }

        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool CheckBorderColision(int width, int height)
        {
            if (_xPosition + _xSpeed + _radius >= width || _yPosition + _ySpeed + _radius >= height
                || _xPosition - _radius * 2 + _xSpeed <= 0 || _yPosition - _radius * 2 + _ySpeed <= 0) { return false; }
            return true;
        }
      

        public override void OppositeXSpeed()
        {
            XSpeed *= -1.0;
        }

        public override void OppositeYSpeed()
        {
            YSpeed *= -1.0;
        }
    }
}

