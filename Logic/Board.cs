using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class Board : LogicAbstractAPI
    {
        private int _boardWidth { get; }
        private int _boardHeight { get; }
        private int _ballRadius { get; }
        private List<IBall> _balls;
        private List<Task> _tasks;
        private DataAbstractAPI _dataAPI;
        private bool _isRunning = false;
        private SemaphoreSlim _Semaphore = new SemaphoreSlim(1);

        public override IBall CreateBall(int xPos, int yPos, int radius, int xSpeed = 0, int ySpeed = 0)
        {

            IBall ball = new Ball(xPos, yPos, radius, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, int ballRadius, DataAbstractAPI dataAPI)
        {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;
            this._ballRadius = ballRadius;
            this._dataAPI = dataAPI;
            this._balls = new List<IBall>();
            this._tasks = new List<Task>();
        }
        public override void AddBalls(int n)
        {
            for (int i = 0; i < n; i++)
            {
                IBall ball = CreateRandomBallLocation();
                Task task = new Task(async () =>
                {

                    while (this._isRunning)
                    {
                        await this._Semaphore.WaitAsync();
                        ball.ChangeSpeed(GenerateRandomInt(-3, 3), GenerateRandomInt(-3, 3));
                        if (ball.CheckBorderColision(_boardWidth, _boardHeight))
                        {
                            ball.MoveBall();
                        }
                        _Semaphore.Release();
                        await Task.Delay(10);
                    }
                });
                _tasks.Add(task);
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



        public override IBall CreateRandomBallLocation()
        {
            return CreateBall(GenerateRandomInt(0 + 2 * _ballRadius, _boardWidth - _ballRadius),
                     GenerateRandomInt(0 + 2 * _ballRadius, _boardHeight - _ballRadius), _ballRadius,
                     GenerateRandomInt(-1, 1), GenerateRandomInt(-1, 1));
        }

        private int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        public override List<IBall> GetBalls()
        {
            return _balls;
        }
    }

}
