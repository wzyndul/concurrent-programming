using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data
{
    public class Board : DataAbstractAPI
    {
        private int _boardWidth {  get; }
        private int _boardHeight { get; }
        private List<IBall> _balls = new List<IBall>();
        public override IBall CreateBall(int xPosition, int yPosition, int xSpeed = 0, int ySpeed = 0)
        {
            IBall ball = new Ball(xPosition, yPosition, xSpeed, ySpeed);
            this.AddBall(ball);   // może się pozbyć tej metody AddBall w ogóle
            return ball;
        }

        public Board(int boardWidth, int boardHeight) {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;     
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

        public override (int, int) GetBoardDimensions()
        {
            return(this._boardWidth, this._boardHeight);
        }
        public override (int, int) GetBallCordinates(IBall ball)
        {
            return ball.GetBallPosition();
        }
        public override (int, int) GetBallSpeed(IBall ball)
        {
            return ball.GetBallSpeed();
        }
        public override int GetBallRadius(IBall ball)
        {
            return ball.GetBallRadius(); 
        }
    }
}



