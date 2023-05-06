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
        private double _ballRadius { get; }

        public override int BoardWidth {
            get => _boardWidth;
            }

        public override int BoardHeight
        {
            get => _boardHeight;
        }
        public override double BallRadius
        {
            get => _ballRadius;
        }

        private List<IDataBall> _balls;


        public override IDataBall CreateBall(double xPos, double yPos, double radius, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {

            IDataBall ball = new DataBall(xPos, yPos, radius, weight, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, double ballRadius)
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
            return CreateBall(GenerateRandomDouble(0 + 2 * _ballRadius, _boardWidth - _ballRadius),
                     GenerateRandomDouble(0 + 2 * _ballRadius, _boardHeight - _ballRadius), _ballRadius, GenerateRandomInt(1, 5),
                     GenerateRandomDouble(-1, 1), GenerateRandomDouble(-1, 1));
        }

        private double GenerateRandomDouble(double min, double max)
        {
            Random rand = new Random();
            return rand.NextDouble() * (max - min) + min;
        }
        private int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

    }
}
