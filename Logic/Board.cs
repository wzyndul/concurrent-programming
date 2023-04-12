using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board : LogicAbstractAPI
    {
        private int _boardWidth { get; }
        private int _boardHeight { get; }
        private int _ballRadius { get; } 
        private List<IBall> _balls = new List<IBall>();

        public override IBall CreateBall(int xPos, int yPos, int xSpeed = 0, int ySpeed = 0)
        {
            if (IsBallOutOfBounds(xPos, yPos, this._ballRadius, xSpeed, ySpeed))
            {
                throw new Exception("Ball is out of bounds");   // może custom exception albo coś innego
            }

            IBall ball = new Ball(xPos, yPos, this._ballRadius, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, int ballRadius)
        {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;
            this._ballRadius = ballRadius;
        }
        public override void AddBall(IBall ball)
        {
            _balls.Add(ball);
        }

        public override void ClearBoard()
        {
            _balls.Clear();
        }

        public override List<IBall> GetBalls()
        {
            return new List<IBall>(_balls); // zeby nie zwarcac referencji do naszej listy, zwracamy kopie
        }

        public override void MoveBall(IBall ball)
        {
            ball.MoveBall();
        }

        private bool IsBallOutOfBounds(int xPos, int yPos, int radius, int xSpeed, int ySpeed)
        {
            bool isBallOutOfBounds =   // zmienilem to idk czy dobrze
                xPos > _boardWidth - radius || yPos > _boardHeight - radius ||
                xSpeed > _boardWidth - radius || ySpeed > _boardHeight - radius;
              
            return isBallOutOfBounds;
        }

        public override (int, int) GetBoardDimensions()
        {
            return (this._boardWidth, this._boardHeight);
        }
        public override (int, int) GetBallCordinates(IBall ball)
        {
            return ball.GetBallPosition();
        }
        public override (int, int) GetBallSpeed(IBall ball)
        {
            return ball.GetBallSpeed();
        }
        public override int GetBallRadius()
        {
            return _ballRadius;
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











    }
}
