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
        // A static factory method that creates a new instance
        // of the Board class and returns it as an object of the LogicAbstractAPI type
        public static LogicAbstractAPI CreateAPI(int boardWidth, int boardHeight, int ballRadius = 5)
        {
            return new Board(boardWidth, boardHeight, ballRadius);
        }
        public abstract void AddBall(IBall ball);
        public abstract IBall CreateBall(int xPosition, int yPosition, int xSpeed = 0, int ySpeed = 0);
        public abstract List<IBall> GetBalls();
        public abstract void ClearBoard();
        public abstract void MoveBall(IBall ball);

        // idk czy te metody potrzebne, czy inaczej to robić
        public abstract (int, int) GetBoardDimensions();
        public abstract (int, int) GetBallSpeed(IBall ball);
        public abstract (int, int) GetBallCordinates(IBall ball);
        public abstract int GetBallRadius();

        public abstract IBall CreateRandomBallLocation();


    }
}
