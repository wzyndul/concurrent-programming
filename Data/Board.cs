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
        private LoggerAbstract _logger = LoggerAbstract.CreateLogger();


        public override IDataBall CreateBall(int id,float xPos, float yPos, float xSpeed, float ySpeed)
        {

            IDataBall ball = new DataBall(id, xPos, yPos, xSpeed, ySpeed, _logger);
            _balls.Add(ball);
            return ball;
        }


        public Board(int boardWidth, int boardHeight, double ballRadius)             
        {
            this._boardWidth = boardWidth;
            this._boardHeight = boardHeight;
            this._ballRadius = ballRadius;
            this._balls = new List<IDataBall>();
            _logger.AddBoardToSave(this);
        }



        public override void ClearBoard()
        {
            foreach (IDataBall b in _balls)
            {
                b.Dispose();
            }
            _balls.Clear();
        }


        public override List<IDataBall> GetBalls()
        {
            return _balls;
        }


        public override IDataBall CreateRandomBallLocation(List<IDataBall> balls, int id)
        {
            float xPos;
            float yPos;

            // generate random position until it is not the same as any existing ball
            do
            {
                xPos = GenerateRandomFloat(4f * (float)_ballRadius, (float)_boardWidth - (float)_ballRadius);
                yPos = GenerateRandomFloat(4f * (float)_ballRadius, (float)_boardHeight - (float)_ballRadius);
            } while (balls.Any(b => Math.Sqrt(Math.Pow(b.Position.X - xPos, 2) + Math.Pow(b.Position.Y - yPos, 2)) <= 2 * _ballRadius));

            float xSpeed;
            float ySpeed;

            // speed can't be 0
            do
            {
                xSpeed = GenerateRandomFloat(-1.5f, 1.5f);
                ySpeed = GenerateRandomFloat(-1.5f, 1.5f);
            } while (xSpeed == 0.0f || ySpeed == 0.0f);

            return CreateBall(id, xPos, yPos, xSpeed, ySpeed);
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

        private float GenerateRandomFloat(float min, float max)
        {
            Random rand = new Random();
            return (float)rand.NextDouble() * (max - min) + min;
        }
        private int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

    }
}
