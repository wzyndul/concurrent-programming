using System;
using System.Collections.Generic;
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
        private double _ballRadius { get; }         // tu stala wartosc??
        private DataAbstractAPI _data;
        private List<ILogicBall> _balls;
        private List<Task> _tasks;
        private bool _isRunning = false;
        private SemaphoreSlim _Semaphore = new SemaphoreSlim(1);

        public override ILogicBall CreateBall(double xPos, double yPos,  int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {

            ILogicBall ball = new LogicBall(xPos, yPos, weight, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public BallManager(DataAbstractAPI dataLayer)
        {
            this._data = dataLayer;
            this._boardWidth = _data.BoardWidth;
            this._boardHeight = _data.BoardHeight;
            this._ballRadius = _data.BallRadius;
            this._balls = new List<ILogicBall>();
            this._tasks = new List<Task>();
        }
        public override void AddBalls(int n)
        {
            for (int i = 0; i < n; i++)
            {
                IDataBall dataBall = _data.CreateRandomBallLocation();
                ILogicBall logicBall = CreateBall(dataBall.XPosition, dataBall.YPosition, dataBall.Weight, dataBall.XSpeed, dataBall.YSpeed);
                dataBall.PropertyChanged += logicBall.UpdateBall!;
                _balls.Add(logicBall);

                Task task = new Task(async () =>
                {

                    while (this._isRunning)
                    {
                        await this._Semaphore.WaitAsync();
                        //if (dataBall.CheckBorderColision(_boardWidth, _boardHeight))
                        //{
                        //    dataBall.MoveBall();
                        //}
                        WallCollision(dataBall);
                        dataBall.MoveBall();
                        _Semaphore.Release();
                        await Task.Delay(10);
                    }
                });
                _tasks.Add(task);
            }
        }

        private void WallCollision(IDataBall ball)
        {
            if (ball.XPosition + ball.XSpeed + _ballRadius >= _boardWidth || ball.XPosition + ball.XSpeed <= 2 * _ballRadius) {
                ball.OppositeXSpeed();
            }

            if (ball.YPosition + ball.YSpeed + _ballRadius >= _boardHeight || ball.YPosition + ball.YSpeed <= 2 * _ballRadius)
            {
                ball.OppositeYSpeed();
            }

        }


        public override void ClearBoard()
        {
            _isRunning = false;
            bool isAllTasksCompleted = false;

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
            _tasks.Clear();
            _balls.Clear();
        }




        public override void MoveBalls()
        {
            this._isRunning = true;
            foreach (Task task in this._tasks)
            {

                task.Start();

            }

        }

        public override List<ILogicBall> GetBalls()
        {
            return _balls;
        }
    }
}
