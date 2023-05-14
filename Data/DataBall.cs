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
        private Vector2 _velocity { get; set; }

        public override event EventHandler<DataBallEventArgs>? DataBallPositionChanged;
        internal DataBall(float xPosition, float yPosition, int weight, float xSpeed, float ySpeed)
        {
            _position = new Vector2(xPosition, yPosition);
            _velocity = new Vector2(xSpeed, ySpeed);
            _weight = weight;
            Task.Run(StartMoving);
        }

        private void MoveBall()
        {
            Vector2 movedPos = new Vector2(Position.X + Velocity.X, Position.Y + Velocity.Y);
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

        public override void ClearBalls()
        {
/*            bool isAllTasksCompleted = false;


            while (!isAllTasksCompleted)
            {
                isAllTasksCompleted = true;
                foreach (Task task in _tasks)
                {
                    if (!task.IsCompleted)
                    {
                        isAllTasksCompleted = false;
                        break;
                    }
                }
            }

            foreach (Task task in _tasks)
            {
                try
                {
                    task.Dispose();
                }
                catch (Exception ex) { }
            }
            _tasks.Clear();*/
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


        public override Vector2 Velocity
        {
            get => _velocity;

            set
            {
                if (_velocity != value)
                {
                    _velocity = value;
                }
            }
        }
    }
}

