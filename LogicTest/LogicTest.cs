﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class LogicTest
    {
        internal class ImpostorDataAPI : DataAbstractAPI
        {
            private int _boardWidth { get; }
            private int _boardHeight { get; }
            private double _ballRadius { get; }
            private List<IDataBall> _balls;

            public override IDataBall CreateBall(float xPos, float yPos, int weight, float xSpeed, float ySpeed)
            {
                IDataBall ball = IDataBall.CreateBall(xPos, yPos, weight, xSpeed, ySpeed);
                _balls.Add(ball);
                return ball;
            }

            public ImpostorDataAPI(int boardWidth, int boardHeight, double ballRadius)
            {
                this._boardWidth = boardWidth;
                this._boardHeight = boardHeight;
                this._ballRadius = ballRadius;
                this._balls = new List<IDataBall>();
            }

            public override void ClearBoard()
            {
                _balls.Clear();
            }


            public override List<IDataBall> GetBalls()
            {
                return _balls;
            }


            public override IDataBall CreateRandomBallLocation(List<IDataBall> balls)
            {
                float xPos;
                float yPos;

                // generate random position until it is not the same as any existing ball
                do
                {
                    xPos = GenerateRandomFloat(4f * (float)_ballRadius, (float)_boardWidth - (float)_ballRadius);
                    yPos = GenerateRandomFloat(4f * (float)_ballRadius, (float)_boardHeight - (float)_ballRadius);
                } while (balls.Any(b => Math.Sqrt(Math.Pow(b.Position.X - xPos, 2) + Math.Pow(b.Position.Y - yPos, 2)) <= 2 * _ballRadius));

                float xSpeed;
                float ySpeed;

                // speed can't be 0
                do
                {
                    xSpeed = GenerateRandomFloat(-1.5f, 1.5f);
                    ySpeed = GenerateRandomFloat(-1.5f, 1.5f);
                } while (xSpeed == 0.0f || ySpeed == 0.0f);

                return CreateBall(xPos, yPos, 20, xSpeed, ySpeed);
            }




            public override int BoardWidth
            {
                get => _boardWidth;
            }

            public override int BoardHeight
            {
                get => _boardHeight;
            }

            public override double BallRadius
            {
                get => _ballRadius;
            }


            // Helper method

            private float GenerateRandomFloat(float min, float max)
            {
                Random rand = new Random();
                return (float)rand.NextDouble() * (max - min) + min;
            }
        }

        
        [TestMethod]
        public void CreateBallGetBallsTest()
        {
            ImpostorDataAPI impostorDataAPI = new ImpostorDataAPI(500, 400, 10);
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateAPI(500, 400, 10, impostorDataAPI);
            ILogicBall ball = logicAPI.CreateBall(1, 1);
            Assert.AreEqual(1, ball.Position.X);
            Assert.AreEqual(1, ball.Position.Y);
            CollectionAssert.Contains(logicAPI.GetBalls(), ball);
        }

        [TestMethod]
        public void GetBallsTest()
        {
            ImpostorDataAPI impostorDataAPI = new ImpostorDataAPI(500, 400, 10);
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateAPI(500, 400, 10, impostorDataAPI);
            logicAPI.CreateBall(1, 1);
            logicAPI.CreateBall(5, 5);
            Assert.AreEqual(2, logicAPI.GetBalls().Count());
        }

        [TestMethod]
        public void ClearBoardTest()
        {
            ImpostorDataAPI impostorDataAPI = new ImpostorDataAPI(500, 400, 10);
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateAPI(500, 400, 10, impostorDataAPI);
            logicAPI.AddBalls(5);
            logicAPI.ClearBoard();
            Assert.AreEqual(0, logicAPI.GetBalls().Count());
        }
    }
}
