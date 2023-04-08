//using Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logic
//{
//    public abstract class LogicAbstractAPI
//    {
//        public static LogicAbstractAPI CreateAPI(double boardWidth, double boardHeight, double ballRadius)
//        {
//            return new BoardManager(boardWidth, boardHeight, ballRadius);
//        }

//        public abstract void CreateBall(double xPos, double yPos, double xSpeed, double ySpeed);
//        public abstract void CreateRandomBallLocation();
//        public abstract List<Ball> GetAllBalls();
//        public abstract void ClearBoard();

//    }
//}
