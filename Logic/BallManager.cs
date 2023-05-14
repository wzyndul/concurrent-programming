using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class BallManager : LogicAbstractAPI
    {
        private int _boardWidth { get; }
        private int _boardHeight { get; }
        private double _ballRadius { get; }        
        private DataAbstractAPI _data;
        private List<ILogicBall> _balls;
        

        public BallManager(DataAbstractAPI dataLayer)
        {
            this._data = dataLayer;
            this._boardWidth = _data.BoardWidth;
            this._boardHeight = _data.BoardHeight;
            this._ballRadius = _data.BallRadius;
            this._balls = new List<ILogicBall>();
        }

        public override ILogicBall CreateBall(float xPos, float yPos)
        {

            ILogicBall ball = new LogicBall(xPos, yPos);
            _balls.Add(ball);
            return ball;
        }


        public override void AddBalls(int n)
        {
            for (int i = 0; i < n; i++)
            {
                IDataBall dataBall = _data.CreateRandomBallLocation(_data.GetBalls());
                ILogicBall logicBall = CreateBall(dataBall.Position.X, dataBall.Position.Y);

                dataBall.DataBallPositionChanged += logicBall.UpdateBall!;
                dataBall.DataBallPositionChanged += WallCollision!;
                dataBall.DataBallPositionChanged += BallsCollision!;

                _balls.Add(logicBall);

            }
        }

        public override List<ILogicBall> GetBalls()
        {
            return _balls;
        }

        public override void ClearBoard()
        {
            foreach (ILogicBall logicBall in _balls)
            {
                foreach (IDataBall dataBall in _data.GetBalls())
                {
                    dataBall.DataBallPositionChanged -= logicBall.UpdateBall!;
                    dataBall.DataBallPositionChanged -= WallCollision!;
                    dataBall.DataBallPositionChanged -= BallsCollision!;
                }
            }
            _balls.Clear();
        }




        private void WallCollision(Object source, DataBallEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            if (ball.Position.X + ball.Velocity.X + _ballRadius > _boardWidth || ball.Position.X + ball.Velocity.X - _ballRadius < 0)
            {
                ball.Velocity = new Vector2(-ball.Velocity.X, ball.Velocity.Y);
            }

            if (ball.Position.Y + ball.Velocity.Y + _ballRadius > _boardHeight || ball.Position.Y + ball.Velocity.Y - _ballRadius < 0)
            {
                ball.Velocity = new Vector2(ball.Velocity.X, -ball.Velocity.Y);
            }

        }

        /*        private void WallCollision(Object source, DataBallEventArgs e)
                {
                    IDataBall ball = (IDataBall)source;
                    if (0 >= (ball.Position.X - _ballRadius) ||
                        (ball.Position.X + _ballRadius) >= _boardWidth - 5)
                    {
                        ball.Velocity = new Vector2(-ball.Velocity.X, ball.Velocity.Y);
                    }

                    if (0 >= (ball.Position.Y - _ballRadius) ||
                        (ball.Position.Y + _ballRadius) >= _boardHeight)
                    {
                        ball.Velocity = new Vector2(ball.Velocity.X, -ball.Velocity.Y);
                    }

                }*/




        private void BallsCollision(Object source, DataBallEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            List<IDataBall> collidingBalls = new List<IDataBall>();
            foreach (IDataBall otherBall in _data.GetBalls())
            {
                double distance = Math.Sqrt(Math.Pow(ball.Position.X + ball.Velocity.X - (otherBall.Position.X + otherBall.Velocity.X), 2)
                                + Math.Pow(ball.Position.Y + ball.Velocity.Y - (otherBall.Position.Y + otherBall.Velocity.Y), 2));
                if (otherBall != ball && distance <= _ballRadius * 2)
                {
                    collidingBalls.Add(otherBall);
                }
            }

            lock (collidingBalls)
            {
                foreach (IDataBall otherBall in collidingBalls)
                {
                    float otherBallXSpeed = otherBall.Velocity.X * (otherBall.Weight - ball.Weight) / (otherBall.Weight + ball.Weight)
                                           + ball.Weight * ball.Velocity.X * 2f / (otherBall.Weight + ball.Weight);
                    float otherBallYSpeed = otherBall.Velocity.Y * (otherBall.Weight - ball.Weight) / (otherBall.Weight + ball.Weight)
                                           + ball.Weight * ball.Velocity.Y * 2f / (otherBall.Weight + ball.Weight);

                    float ballXSpeed = ball.Velocity.X * (ball.Weight - otherBall.Weight) / (ball.Weight + ball.Weight)
                                      + otherBall.Weight * otherBall.Velocity.X * 2f / (ball.Weight + otherBall.Weight);
                    float ballYSpeed = ball.Velocity.Y * (ball.Weight - otherBall.Weight) / (ball.Weight + ball.Weight)
                                      + otherBall.Weight * otherBall.Velocity.Y * 2f / (ball.Weight + otherBall.Weight);

                    otherBall.Velocity = new Vector2(otherBallXSpeed, otherBallYSpeed);
                    ball.Velocity = new Vector2(ballXSpeed, ballYSpeed);

                }
            }

        }


    }
}
