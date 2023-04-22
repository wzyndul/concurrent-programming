using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateAPI(int boardWidth, int boardHeight, int ballRadius, DataAbstractAPI dataAbstractAPI = default)
        {
            return new Board(boardWidth, boardHeight, ballRadius, dataAbstractAPI ?? DataAbstractAPI.CreateAPI());
        }
        public abstract void AddBalls(int number);
        public abstract IBall CreateBall(int xPosition, int yPosition,int radius, int xSpeed = 0, int ySpeed = 0);
        public abstract void ClearBoard();
        public abstract void MoveBalls();


        public abstract IBall CreateRandomBallLocation();
        public abstract List<IBall> GetBalls();
    }
}
