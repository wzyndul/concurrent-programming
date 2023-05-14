using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ModelBall : IModelBall, INotifyPropertyChanged
    {
        private float _xPosition { get; set; }
        private float _yPosition { get; set; }

        public ModelBall(float xPos, float yPos)
        {
            _xPosition = xPos;
            _yPosition = yPos;
        }


        public override void UpdateBall(Object source, LogicBallEventArgs e) 
        {
            ILogicBall sourceBall = (ILogicBall)source;
            XPosition = sourceBall.Position.X;
            YPosition = sourceBall.Position.Y;
        }



        public override float XPosition
        {
            get => _xPosition;
            set
            {
                if (_xPosition != value)
                {
                    _xPosition = value;
                    RaisePropertyChanged(() => XPosition);
                }
            }
        }




        public override float YPosition
        {
            get => _yPosition;
            set
            {
                if (_yPosition != value)
                {
                    _yPosition = value;
                    RaisePropertyChanged(() => YPosition);
                }
            }
        }


        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                string propertyName = memberExpression.Member.Name;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
