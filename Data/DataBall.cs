using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataBall : IDataBall
    {
        private Vector2 _position { get; set; }
        private int _weight { get; }
        private float _xSpeed { get; set; }
        private float _ySpeed { get; set; }

        public override event EventHandler<DataBallEventArgs>? DataBallPositionChanged;
        internal DataBall(float xPosition, float yPosition, int weight, float xSpeed, float ySpeed)
        {
            _position = new Vector2(xPosition, yPosition);
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _weight = weight;
            Task.Run(StartMoving);
        }

        private void MoveBall()
        {
            Vector2 movedPos = new Vector2(Position.X + XSpeed, Position.Y + YSpeed);
            Position = movedPos;
            
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

        public override Vector2 Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                }
            }
        }

        public override int Weight
        {
            get => _weight;
        }


        public override float XSpeed
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
        public override float YSpeed
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

