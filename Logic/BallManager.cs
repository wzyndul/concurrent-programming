﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        private Object _lockBalls = new Object();


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
                IDataBall dataBall = _data.CreateRandomBallLocation(_data.GetBalls(), i);
                ILogicBall logicBall = CreateBall(dataBall.Position.X, dataBall.Position.Y);

                dataBall.DataBallPositionChanged += logicBall.UpdateBall!;
                dataBall.DataBallPositionChanged += WallCollision!;
                dataBall.DataBallPositionChanged += CheckCollision!;
            }
        }

        public override List<ILogicBall> GetBalls()
        {
            return _balls;
        }

        public override void ClearBoard()
        {
            _data.ClearBoard();
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




        private void BallsCollision(IDataBall ball, IDataBall otherBall)
        {
            float otherBallXSpeed = otherBall.Velocity.X;
            float otherBallYSpeed = otherBall.Velocity.Y;

            float ballXSpeed = ball.Velocity.X;
            float ballYSpeed = ball.Velocity.Y;

            otherBall.Velocity = new Vector2(ballXSpeed, ballYSpeed);
            ball.Velocity = new Vector2(otherBallXSpeed, otherBallYSpeed);

        }

        private void CheckCollision(Object source, DataBallEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            lock (_lockBalls)
            {
                foreach (IDataBall otherBall in _data.GetBalls().ToArray())
                {
                    double distance = Math.Sqrt(Math.Pow(ball.Position.X + ball.Velocity.X - (otherBall.Position.X + otherBall.Velocity.X), 2)
                                    + Math.Pow(ball.Position.Y + ball.Velocity.Y - (otherBall.Position.Y + otherBall.Velocity.Y), 2));
                    if (otherBall != ball && distance <= _ballRadius * 2)
                    {
                        BallsCollision(ball, otherBall);
                    }
                }
            }
        }
    }


}
