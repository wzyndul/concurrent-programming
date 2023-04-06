using Data;

namespace Logic
{
    internal class BoardManager : LogicAbstractAPI
    {
        private double _boardHeight;
        private double _boardWidth;
        private double _ballRadius = 5.0;
        private List<Ball> _balls = new();

        public BoardManager(double boardHeight, double boardWidth, double ballRadius)
        {
            this._boardHeight = boardHeight;
            this._boardWidth = boardWidth;
            this._ballRadius = ballRadius;
        }

        public override void CreateBall(double xPos, double yPos, double xSpeed, double ySpeed)
        {
            if (IsBallOutOfBounds(xPos, yPos, xSpeed, ySpeed)) 
            {
                throw new Exception("Ball is out of bounds");   // może custom exception albo coś innego
            }
            
            Ball ball = new(xPos, yPos, xSpeed, ySpeed);
            _balls.Add(ball);
        }

        public override void CreateRandomBallLocation()
        {
            CreateBall(GenerateRandomDouble(_ballRadius, _boardWidth - _ballRadius),
                     GenerateRandomDouble(_ballRadius, _boardHeight - _ballRadius),
                     GenerateRandomDouble(-5.0, 5.0), GenerateRandomDouble(-5.0, 5.0));     // 5.0 - max prędkość na razie
        }


        public override List<Ball> GetAllBalls()
        {
            return _balls;
        }

        public override void ClearBoard()
        {
            _balls.Clear();
        }



        private bool IsBallOutOfBounds(double xPos, double yPos, double xSpeed, double ySpeed)
        {
            bool isBallOutOfBounds =
                xPos > _boardWidth - _ballRadius || yPos > _boardHeight - _ballRadius ||
                xPos < _ballRadius || yPos < _ballRadius ||
                xSpeed > _boardHeight - _ballRadius || ySpeed > _boardWidth - _ballRadius ||
                xSpeed < -(_boardWidth - _ballRadius) || ySpeed < -(_boardHeight - _ballRadius);
            return isBallOutOfBounds;
        }

        private double GenerateRandomDouble(double min,  double max)
        {
            Random rand = new Random();
            return rand.NextDouble() * (max - min) + min;
        }


    }
}