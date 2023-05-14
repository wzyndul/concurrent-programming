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


        public override IDataBall CreateRandomBallLocation(List<IDataBall> balls)
        {
            double xPos;
            double yPos;

            // generate random position until it is not the same as any existing ball
            do
            {
                xPos = GenerateRandomDouble(4 * _ballRadius, _boardWidth - _ballRadius);
                yPos = GenerateRandomDouble(4 * _ballRadius, _boardHeight - _ballRadius);
            } while (balls.Any(b => Math.Sqrt(Math.Pow(b.XPosition - xPos, 2) + Math.Pow(b.YPosition - yPos, 2)) <= 2 * _ballRadius));

            double xSpeed;
            double ySpeed;

            // speed can't be 0
            do
            {
                xSpeed = GenerateRandomDouble(-1.5, 1.5);
                ySpeed = GenerateRandomDouble(-1.5, 1.5);
            } while (xSpeed == 0 || ySpeed == 0);

            return CreateBall(xPos, yPos, 20, xSpeed, ySpeed);
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
            return rand.NextDouble() * (max - min) + min;
        }
        private int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

    }
}
