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
    internal class DataBall : IDataBall
    {
        private double _xPosition { get; set; }
        private double _yPosition { get; set; }
        private int _weight { get; }
        private double _xSpeed { get; set; }
        private double _ySpeed { get; set; }

        public override event EventHandler<DataBallEventArgs>? DataBallPositionChanged;
        internal DataBall(double xPosition, double yPosition, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _weight = weight;
            Task.Run(StartMoving);
        }

        private void MoveBall()
        {
            XPosition += XSpeed;
            YPosition += YSpeed;
            DataBallEventArgs args = new DataBallEventArgs(this);
            DataBallPositionChanged?.Invoke(this, args);

        }

        private async void StartMoving()
        {
            while (true)
            {
                lock (this)
                {
                    MoveBall();
                }
                await Task.Delay(10);

            }
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
                }
            }
        }

        public override int Weight
        {
            get => _weight;
        }


        public override double XSpeed
        {
            get => _xSpeed;
            set
            {
                if (_xSpeed != value)
                {
                    _xSpeed = value;               
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
                }
            }
        }

        

    }
}

