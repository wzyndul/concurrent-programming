using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
        //private double _radius { get; set; }
        private int _weight { get; }

        internal DataBall(double xPosition, double yPosition, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            //_radius = radius;
            _weight = weight;
        }


        // miało być prywatne ponoć???
        public override void MoveBall()
        {
            this.XPosition += _xSpeed;
            this.YPosition += _ySpeed;
        }


        // przeniesione do boarda ale na razie tu zostawiam
        /*public override bool CheckBorderColision(int width, int height)
        {
            if (_xPosition + _xSpeed + _radius >= width || _yPosition + _ySpeed + _radius >= height
                || _xPosition - _radius * 2 + _xSpeed <= 0 || _yPosition - _radius * 2 + _ySpeed <= 0) { return false; }
            return true;
        }*/


        public override void OppositeXSpeed()
        {
            XSpeed *= -1.0;
        }

        public override void OppositeYSpeed()
        {
            YSpeed *= -1.0;
        }



        // Properties 

        public override double XPosition
        {
            get => _xPosition;
            set
            {
                if (_xPosition != value)
                {
                    _xPosition = value;
                    RaisePropertyChanged(() => XPosition);
                }
            }
        }

        public override double YPosition
        {
            get => _yPosition;
            set
            {
                if (_yPosition != value)
                {
                    _yPosition = value;
                    RaisePropertyChanged(() => YPosition);
                }
            }
        }

        public override int Weight
        {
            get => _weight;
        }

        /*public override double Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                RaisePropertyChanged();
            }
        }*/

        public override double XSpeed
        {
            get => _xSpeed;
            set
            {
                if (_xSpeed != value)
                {
                    _xSpeed = value;
                    RaisePropertyChanged(() => XSpeed);
                }
            }
        }
        public override double YSpeed
        {
            get => _ySpeed;
            set
            {
                if (_ySpeed != value)
                {
                    _ySpeed = value;
                    RaisePropertyChanged(() => YSpeed);
                }
            }
        }

        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                string propertyName = memberExpression.Member.Name;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

