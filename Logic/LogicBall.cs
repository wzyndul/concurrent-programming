using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Logic
{
    internal class LogicBall : ILogicBall
    {
        private double _xPosition { get; set; }
        private double _yPosition { get; set; }


        internal LogicBall(double xPosition, double yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;

        }


        // Properties 
        public override double XPosition
        {
            get => _xPosition;
            set
            {
                if (_xPosition != value)
                {
                    _xPosition = value;                   
                }
            }
        }

        public override double YPosition
        {
            get => _yPosition;
            set
            {
                if (_yPosition != value)
                {
                    _yPosition = value;                 
                }
            }
        }

        public override event EventHandler<LogicBallEventArgs> LogicBallPositionChanged;


        public override void UpdateBall(object source, DataBallEventArgs e)
        {
            IDataBall ball = (IDataBall)source;
            XPosition = ball.XPosition;
            YPosition = ball.YPosition;
            LogicBallEventArgs args = new LogicBallEventArgs(this);
            LogicBallPositionChanged?.Invoke(this, args);
        }
    }
}

