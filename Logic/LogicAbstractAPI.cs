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
        public abstract ILogicBall CreateBall(double xPosition, double yPosition);

        public abstract void AddBalls(int number);
        public abstract List<ILogicBall> GetBalls();
        public abstract void ClearBoard();
    }
}
