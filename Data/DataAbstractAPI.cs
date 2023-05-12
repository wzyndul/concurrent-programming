using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateAPI(int boardWidth, int boardHeight, double ballRadius)
        {
            return new Board(boardWidth, boardHeight, ballRadius);
        }
        public abstract IDataBall CreateBall(double xPosition, double yPosition, int weight, double xSpeed = 0.0, double ySpeed = 0.0);

        public abstract void ClearBoard();
        public abstract List<IDataBall> GetBalls();
        public abstract IDataBall CreateRandomBallLocation();
        public abstract int BoardWidth { get; }
        public abstract int BoardHeight { get; }
        public abstract double BallRadius { get; }
    }
}
