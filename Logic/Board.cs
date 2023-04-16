using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override IBall CreateBall(int xPos, int yPos, int xSpeed = 0, int ySpeed = 0)
        {
            //if (IsBallOutOfBounds(xPos, yPos, this._ballRadius, xSpeed, ySpeed))
            //{
            //    throw new Exception("Ball is out of bounds");   // może custom exception albo coś innego
            //}

            IBall ball = new Ball(xPos, yPos, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, int ballRadius, DataAbstractAPI dataAPI)
        {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;
            this._ballRadius = ballRadius;
            this._dataAPI = dataAPI ?? DataAbstractAPI.CreateAPI();
            this._balls = new List<IBall>();
            this._tasks = new List<Task>();
        }
        public override void AddBalls(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _tasks.Add(new Task(() =>
                {
                    IBall ball = CreateRandomBallLocation();
                    while (true)
                    {
                        ball.ChangeSpeed(GenerateRandomInt(-5, 5), GenerateRandomInt(-5, 5));
                        ball.MoveBall();
                        Thread.Sleep(1000);    // na razie cokolwiek   
                    }
                }));
            }
        }

        public override void ClearBoard()
        {
            foreach(Task task in _tasks)
            {
                task.Dispose();
            }
            _balls.Clear();
        }

     

        public override void MoveBalls()
        {
            foreach(Task task in _tasks)
            {
                task.Start();
            }
        }

        private bool IsBallOutOfBounds(int xPos, int yPos, int radius, int xSpeed, int ySpeed)
        {
            bool isBallOutOfBounds =   // zmienilem to idk czy dobrze
                xPos > _boardWidth - radius || yPos > _boardHeight - radius ||
                xSpeed > _boardWidth - radius || ySpeed > _boardHeight - radius;
              
            return isBallOutOfBounds;
        }



        public override IBall CreateRandomBallLocation()
        {
            return CreateBall(GenerateRandomInt(_ballRadius, _boardWidth - _ballRadius),
                     GenerateRandomInt(_ballRadius, _boardHeight - _ballRadius),
                     GenerateRandomInt(-5, 5), GenerateRandomInt(-5, 5));     // 5.0 - max prędkość na razie
        }

        private int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        public override List<IBall> GetBalls()
        {
            return _balls.ToList();  
        }
        public override List<List<int>> GetAllBallsPosition()
        {
            List<List<int>> list = new List<List<int>>();
            foreach (IBall ball in _balls)
            {
                List<int> two = new List<int>
                {
                    ball.GetXPosition(),
                    ball.GetYPosition()
                };
                list.Add(two);
            }
            return list;
        }
    }
    
}
