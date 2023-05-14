using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public override ILogicBall CreateBall(double xPos, double yPos)
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
                ILogicBall logicBall = CreateBall(dataBall.XPosition, dataBall.YPosition);

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
            if (ball.XPosition + ball.XSpeed + _ballRadius >= _boardWidth || ball.XPosition + ball.XSpeed <= _ballRadius)
            {
                ball.XSpeed *= -1.0;
            }

            if (ball.YPosition + ball.YSpeed + _ballRadius >= _boardHeight || ball.YPosition + ball.YSpeed <= _ballRadius)
            {
                ball.YSpeed *= -1.0;
            }

        }




        private void BallsCollision(Object source, DataBallEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            List<IDataBall> collidingBalls = new List<IDataBall>();
            foreach (IDataBall otherBall in _data.GetBalls())
            {
                double distance = Math.Sqrt(Math.Pow(ball.XPosition + ball.XSpeed - (otherBall.XPosition + otherBall.XSpeed), 2)
                                + Math.Pow(ball.YPosition + ball.YSpeed - (otherBall.YPosition + otherBall.YSpeed), 2));
                if (otherBall != ball && distance <= _ballRadius * 2)
                {
                    collidingBalls.Add(otherBall);
                }
            }

            lock (collidingBalls)
            {
                foreach (IDataBall otherBall in collidingBalls)
                {
                    double otherBallXSpeed = otherBall.XSpeed * (otherBall.Weight - ball.Weight) / (otherBall.Weight + ball.Weight)
                                           + ball.Weight * ball.XSpeed * 2 / (otherBall.Weight + ball.Weight);
                    double otherBallYSpeed = otherBall.YSpeed * (otherBall.Weight - ball.Weight) / (otherBall.Weight + ball.Weight)
                                           + ball.Weight * ball.YSpeed * 2 / (otherBall.Weight + ball.Weight);

                    double ballXSpeed = ball.XSpeed * (ball.Weight - otherBall.Weight) / (ball.Weight + ball.Weight)
                                      + otherBall.Weight * otherBall.XSpeed * 2 / (ball.Weight + otherBall.Weight);
                    double ballYSpeed = ball.YSpeed * (ball.Weight - otherBall.Weight) / (ball.Weight + ball.Weight)
                                      + otherBall.Weight * otherBall.YSpeed * 2 / (ball.Weight + otherBall.Weight);

                    otherBall.XSpeed = otherBallXSpeed;
                    otherBall.YSpeed = otherBallYSpeed;
                    ball.XSpeed = ballXSpeed;
                    ball.YSpeed = ballYSpeed;
                }
            }

        }


    }
}
