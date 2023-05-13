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
        
        private List<Task> _tasks;
        private SemaphoreSlim _Semaphore = new SemaphoreSlim(1);

        public BallManager(DataAbstractAPI dataLayer)
        {
            this._data = dataLayer;
            this._boardWidth = _data.BoardWidth;
            this._boardHeight = _data.BoardHeight;
            this._ballRadius = _data.BallRadius;
            this._balls = new List<ILogicBall>();
            this._tasks = new List<Task>();
        }

        public override ILogicBall CreateBall(double xPos, double yPos,  int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {

            ILogicBall ball = new LogicBall(xPos, yPos, weight, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public override void AddBalls(int n)
        {
            //Barrier barrier = new Barrier(n);  // czy to potrzebne
            for (int i = 0; i < n; i++)
            {
                IDataBall dataBall = _data.CreateRandomBallLocation();
                ILogicBall logicBall = CreateBall(dataBall.XPosition, dataBall.YPosition, dataBall.Weight, dataBall.XSpeed, dataBall.YSpeed);

                dataBall.PropertyChanged += logicBall.UpdateBall!;
                dataBall.PropertyChanged += WallCollision!;
                dataBall.PropertyChanged += BallsCollision!;

                _balls.Add(logicBall);

            }
        }

        public override List<ILogicBall> GetBalls()
        {
            return _balls;
        }

        public override void ClearBoard()
        {
            _balls.Clear();
        }


        private void WallCollision(Object source, PropertyChangedEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            if (ball.XPosition + ball.XSpeed + _ballRadius >= _boardWidth || ball.XPosition + ball.XSpeed <= 2 * _ballRadius)
            {
                ball.XSpeed *= -1.0;
            }

            if (ball.YPosition + ball.YSpeed + _ballRadius >= _boardHeight || ball.YPosition + ball.YSpeed <= 2 * _ballRadius)
            {
                ball.YSpeed *= -1.0;
            }

        }




        private void BallsCollision(Object source, PropertyChangedEventArgs e)
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















        /*        private void BallsCollision(Object source, PropertyChangedEventArgs e)
                {
                    IDataBall ball = (IDataBall)source;
                    foreach (IDataBall otherBall in _data.GetBalls())
                    {
                        if (otherBall != ball)
                        {
                            double distance = Math.Sqrt(Math.Pow(otherBall.XPosition - ball.XPosition, 2) + Math.Pow(otherBall.YPosition - ball.YPosition, 2));
                            if (distance <= _ballRadius)
                            {
                                //lock (ball)
                                //{
                                    BallCollision(ball, otherBall);
                                //}
                            }
                        }
                    }
                }

                private void BallCollision(IDataBall ball, IDataBall otherBall)
                {
                    double distance = Math.Sqrt(Math.Pow(ball.XPosition + ball.XSpeed - (otherBall.XPosition + otherBall.XSpeed), 2)
                                    + Math.Pow(ball.YPosition + ball.YSpeed - (otherBall.YPosition + otherBall.YSpeed), 2));
                    if (otherBall != ball && distance <= _ballRadius * 2)
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



        *//*            List<IDataBall> collidingBalls = new List<IDataBall>();
                    foreach (IDataBall otherBall in _data.GetBalls())
                    {
                        double distance = Math.Sqrt(Math.Pow(ball.XPosition + ball.XSpeed - (otherBall.XPosition + otherBall.XSpeed), 2)
                                        + Math.Pow(ball.YPosition + ball.YSpeed - (otherBall.YPosition + otherBall.YSpeed), 2));
                        if (otherBall != ball && distance <= _ballRadius * 2)
                        {
                            collidingBalls.Add(otherBall);
                        }
                    }*/

        /*           lock (collidingBalls)
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
                   }*//*

                }*/


    }
}
