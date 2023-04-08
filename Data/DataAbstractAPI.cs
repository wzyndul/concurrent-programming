using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    // TESTUJĘ
    public abstract class DataAbstractAPI
    {
        // A static factory method that creates a new instance
        // of the Board class and returns it as an object of the DataAbstractAPI type
        public static DataAbstractAPI CreateAPI(int boardWidth, int boardHeight) { 
            return new Board(boardWidth, boardHeight); 
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
        public abstract int GetBallRadius(IBall ball);
    }
}
