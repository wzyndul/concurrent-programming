using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ModelBall : IModelBall, INotifyPropertyChanged
    {
        private double _xPosition { get; set; }
        private double _yPosition { get; set; }
        //private double _radius { get; set; }

        public ModelBall(double xPos, double yPos)
        {
            this._xPosition = xPos;        
            this._yPosition = yPos;
            //this._radius = radius;
        }


        public override void UpdateBall(Object source, PropertyChangedEventArgs e) 
        {
            ILogicBall sourceBall = (ILogicBall)source;
            if (e.PropertyName == nameof(ILogicBall.XPosition))
            {
                this.XPosition = sourceBall.XPosition - 10.0; //- sourceBall.Radius;       
            }
            if (e.PropertyName == nameof(ILogicBall.YPosition))
            {
                this.YPosition = sourceBall.YPosition - 10.0; //- sourceBall.Radius;               
            }
            /*if (e.PropertyName == "Radius")
            {
                this.Radius = sourceBall.Radius;
            }*/
        }


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

        /*public override double Radius 
        {
            get => _radius;
            set
            {
                _radius = value; 
                RaisePropertyChanged();
            } 
        }*/

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
