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
        public abstract IDataBall CreateBall(int id, float xPosition, float yPosition, float xSpeed, float ySpeed);

        public abstract void ClearBoard();
        public abstract List<IDataBall> GetBalls();
        public abstract IDataBall CreateRandomBallLocation(List<IDataBall> balls, int id);
        public abstract int BoardWidth { get; }
        public abstract int BoardHeight { get; }
        public abstract double BallRadius { get; }
    }
}
