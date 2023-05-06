using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Board : DataAbstractAPI
    {
        private int _boardWidth { get; }
        private int _boardHeight { get; }
        private int _ballRadius { get; }

        public override int BoardWidth {
            get => _boardWidth;
            }

        public override int BoardHeight
        {
            get => _boardHeight;
        }
        public override int BallRadius
        {
            get => _ballRadius;
        }

        private List<IDataBall> _balls;


        public override IDataBall CreateBall(int xPos, int yPos, int radius, int xSpeed = 0, int ySpeed = 0)
        {

            IDataBall ball = new DataBall(xPos, yPos, radius, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, int ballRadius)
        {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;
            this._ballRadius = ballRadius;
            this._balls = new List<IDataBall>();
        }



        public override void ClearBoard()
        {
            _balls.Clear();
        }



        public override List<IDataBall> GetBalls()
        {
            return _balls;
        }
        public override IDataBall CreateRandomBallLocation()
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
    }
}
