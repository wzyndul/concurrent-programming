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
        private List<IDataBall> _balls;


        public override IDataBall CreateBall(double xPos, double yPos, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {

            IDataBall ball = new DataBall(xPos, yPos, weight, xSpeed, ySpeed);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, double ballRadius = 10.0)             // tu dodałam 10.0 na razie
        {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;
            this._ballRadius = ballRadius;
            this._balls = new List<IDataBall>();
        }


        public override void ClearBoard()
        {
            foreach (IDataBall b in _balls) { b.StopMoving(); }
            _balls.Clear();
        }


        public override List<IDataBall> GetBalls()
        {
            return _balls;
        }


        public override IDataBall CreateRandomBallLocation()
        {
            return CreateBall(GenerateRandomDouble(4 * _ballRadius, _boardWidth - _ballRadius),
                     GenerateRandomDouble(4 * _ballRadius, _boardHeight - _ballRadius), 20,                 // tu ustawiamy wagę?
                     GenerateRandomDouble(-1.5, 1.5), GenerateRandomDouble(-1.5, 1.5));
        }



        public override int BoardWidth
        {
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


        // Helper methods

        private double GenerateRandomDouble(double min, double max)
        {
            Random rand = new Random();
            double value;
            do
            {
                value = rand.NextDouble() * (max - min) + min;
            } while (value == 0);
            return value;
        }
        private int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

    }
}
