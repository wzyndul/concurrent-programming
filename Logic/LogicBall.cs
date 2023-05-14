using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Logic
{
    internal class LogicBall : ILogicBall
    {
        private Vector2 _position;


        internal LogicBall(float xPosition, float yPosition)
        {
            _position = new Vector2(xPosition, yPosition);
        }


        // Properties 

        public override Vector2 Position
        {
            get => _position;
        }

        public override event EventHandler<LogicBallEventArgs> LogicBallPositionChanged;


        public override void UpdateBall(object source, DataBallEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            _position = ball.Position;
            LogicBallEventArgs args = new LogicBallEventArgs(this);
            LogicBallPositionChanged?.Invoke(this, args);
        }
    }
}
