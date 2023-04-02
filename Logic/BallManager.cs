using Data;

namespace Logic
{
    public class BallManager
    {
        private double _boardHeight;
        private double _boardWidth;
        private double _ballRadius = 5.0;                   // tak? hardcoded
        private BallRepository _ballRepository = new();

        public BallManager(double boardHeight, double boardWidth, double ballRadius)
        {
            this._boardHeight = boardHeight;
            this._boardWidth = boardWidth;
            this._ballRadius = ballRadius;
        }

        public Ball MakeBall(double xPos, double yPos, double xSpeed, double ySpeed)
        {
            if (_isBallOutOfBounds(xPos, yPos, xSpeed, ySpeed) { }
            
            Ball ball = new(xPos, yPos, xSpeed, ySpeed);
            _ballRepository.Add(ball);
            return ball;
        }

        private bool _isBallOutOfBounds(double xPos, double yPos, double xSpeed, double ySpeed)
        {
            bool isBallOutOfBounds =
                xPos > _boardWidth - _ballRadius || yPos > _boardHeight - _ballRadius ||
                xPos < _ballRadius || yPos < _ballRadius ||
                xSpeed > _boardHeight - _ballRadius || ySpeed > _boardWidth - _ballRadius ||
                xSpeed < -(_boardWidth - _ballRadius) || ySpeed < -(_boardHeight - _ballRadius);
            return isBallOutOfBounds;
        }

 
    }
}