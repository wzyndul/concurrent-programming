using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateAPI(int boardWidth, int boardHeight, int ballRadius, DataAbstractAPI? dataAbstractApi = null)
        {
            return new BallManager(dataAbstractApi ?? DataAbstractAPI.CreateAPI(boardWidth, boardHeight, ballRadius));
        }
        public abstract void AddBalls(int number);
        public abstract ILogicBall CreateBall(int xPosition, int yPosition, int radius, int xSpeed = 0, int ySpeed = 0);
        public abstract void ClearBoard();
        public abstract void MoveBalls();
        public abstract List<ILogicBall> GetBalls();
    }
}
