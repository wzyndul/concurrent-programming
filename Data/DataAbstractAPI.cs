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
        public static DataAbstractAPI CreateAPI(double boardWidth, double boardHeight) { 
            return new Board(boardWidth, boardHeight); 
        }

        public abstract void Connect();
        public abstract void AddBall(Ball ball);
        public abstract List<Ball> GetBalls();
        public abstract void ClearBoard();
    }
}
