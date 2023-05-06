using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateAPI(int boardWidth, int boardHeight, int ballRadius)
        {
            return new Board(boardWidth, boardHeight, ballRadius);
        }
        public abstract IDataBall CreateBall(int xPosition, int yPosition, int radius, int xSpeed = 0, int ySpeed = 0);
        public abstract void ClearBoard();
        public abstract List<IDataBall> GetBalls();
        public abstract int BoardWidth { get; }
        public abstract int BoardHeight { get; }
        public abstract int BallRadius { get; }
        public abstract IDataBall CreateRandomBallLocation();
    }
}
