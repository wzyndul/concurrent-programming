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
                    RaisePropertyChanged(() => XPosition);
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

        public override void UpdateBall(Object source, PropertyChangedEventArgs e)
        {
            // obie wersje chyba dzialaja
            //IDataBall sourceBall = (IDataBall)source;
            GetType().GetProperty(e.PropertyName!)!.SetValue(
                this, source.GetType().GetProperty(e.PropertyName!)!.GetValue(source)
            );
            //this.XPosition = sourceBall.XPosition;
            //this.YPosition = sourceBall.YPosition;
        }
    }
}

