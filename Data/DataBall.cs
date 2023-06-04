using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataBall : IDataBall, IDisposable
    {
        private Vector2 _position;
        private Vector2 _velocity;
        private int _id;
        private bool _isRunning;
        private LoggerAbstract _logger;

        public override event EventHandler<DataBallEventArgs>? DataBallPositionChanged;
        internal DataBall(int id, float xPosition, float yPosition, float xSpeed, float ySpeed, LoggerAbstract logger)
        {
            _id = id;
            _logger = logger;
            _position = new Vector2(xPosition, yPosition);
            _velocity = new Vector2(xSpeed, ySpeed);
            _isRunning = true;
            Task.Run(StartMoving);
        }

        private void MoveBall(float time)
        {
            time = 1f;
            Vector2 _tempPosition = _position;
            Vector2 _tempVelocity = _velocity;
            _tempPosition = new Vector2(_tempPosition.X + _tempVelocity.X * time, _tempPosition.Y + _tempVelocity.Y * time);
            _position = _tempPosition;
            DataBallEventArgs args = new DataBallEventArgs(this);
            DataBallPositionChanged?.Invoke(this, args);

        }

        private async void StartMoving()
        {
            Stopwatch stopwatch = new Stopwatch();
            float timeDifference = 1f;
            while (_isRunning)
            {
                int _inverseSpeed = (int)(5 / Math.Sqrt(_velocity.X * _velocity.X + _velocity.Y * _velocity.Y));
                stopwatch.Start();
                MoveBall(timeDifference);
                _logger.AddBallToSave(this);
                stopwatch.Stop();
                if (_inverseSpeed < 15)
                {
                    await Task.Delay(5 + _inverseSpeed);
                } else
                {
                    await Task.Delay(20);
                }
                timeDifference = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }
        }


        public override void Dispose()
        {
            _isRunning = false;
        }


        // Properties 

        public override Vector2 Position
        {
            get => _position;
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

        public override int Id
        {
            get => _id;
        }
    }
}

