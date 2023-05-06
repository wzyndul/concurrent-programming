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
        public static LogicAbstractAPI CreateAPI(int boardWidth, int boardHeight, double ballRadius, DataAbstractAPI? dataAbstractApi = null)
        {
            return new BallManager(dataAbstractApi ?? DataAbstractAPI.CreateAPI(boardWidth, boardHeight, ballRadius));
        }
        public abstract void AddBalls(int number);
        public abstract ILogicBall CreateBall(double xPosition, double yPosition, double radius, int weight, double xSpeed = 0.0, double ySpeed = 0.0);
        public abstract void ClearBoard();
        public abstract void MoveBalls();
        public abstract List<ILogicBall> GetBalls();
    }
}
