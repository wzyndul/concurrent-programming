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
        private int _weight { get; }
        private Vector2 _velocity;
        private bool _isRunning;
        private LoggerAbstract _logger;

        public override event EventHandler<DataBallEventArgs>? DataBallPositionChanged;
        internal DataBall(float xPosition, float yPosition, int weight, float xSpeed, float ySpeed, LoggerAbstract logger)
        {
            this._logger = logger;
            _position = new Vector2(xPosition, yPosition);
            _velocity = new Vector2(xSpeed, ySpeed);
            _weight = weight;
            _isRunning = true;
            Task.Run(StartMoving);
        }

        private void MoveBall()
        {
            Vector2 _tempPosition = _position;
            Vector2 _tempVelocity = _velocity;
            _tempPosition = new Vector2(_tempPosition.X + _tempVelocity.X, _tempPosition.Y + _tempVelocity.Y);
            _position = _tempPosition;
            DataBallEventArgs args = new DataBallEventArgs(this);
            DataBallPositionChanged?.Invoke(this, args);

        }

        private async void StartMoving()
        {
            Stopwatch stopwatch = new Stopwatch();
            while (_isRunning)
            {
                //double _inverseSpeed = 1 / Math.Sqrt(_velocity.X * _velocity.X + _velocity.Y * _velocity.Y); nie wiem czy z tego bede korzystac
                stopwatch.Start();
                MoveBall();
                _logger.AddLogToSave(this);
                stopwatch.Stop();
                if ((int)stopwatch.ElapsedMilliseconds < 10)
                {
                    await Task.Delay(10 - (int) stopwatch.ElapsedMilliseconds);
                }
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

