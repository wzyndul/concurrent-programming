using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateAPI(int boardWidth, int boardHeight)
        {
            return new BoardManager(DataAbstractAPI.CreateAPI(boardWidth, boardHeight));
        }
        public abstract List<IBall> GetBalls();
        public abstract void ClearBoard();
        public abstract void AddBall(IBall ball);
        public abstract IBall CreateBall(int xPosition, int yPosition, int xSpeed, int ySpeed);
        public abstract IBall CreateBallRandom();

        // idk czy te metody potrzebne, czy inaczej to robić

        public abstract (int, int) GetBoardDimensions();
        public abstract (int, int) GetBallSpeed(IBall ball);
        public abstract (int, int) GetBallCordinates(IBall ball);
        public abstract int GetBallRadius(IBall ball);


    }
}
