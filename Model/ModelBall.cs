using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ModelBall : IModelBall, INotifyPropertyChanged
    {
        private double _xPosition { get; set; }
        private double _yPosition { get; set; }
        private double _radius { get; set; }

        public ModelBall(double xPos, double yPos, double radius)
        {
            this._xPosition = xPos;        
            this._yPosition = yPos;
            this._radius = radius;
        }


        public override void UpdateBall(Object source, PropertyChangedEventArgs e) 
        {
            ILogicBall sourceBall = (ILogicBall)source;
            if (e.PropertyName == "XPosition")
            {
                this.XPosition = sourceBall.XPosition - sourceBall.Radius;       
            }
            if (e.PropertyName == "YPosition")
            {
                this.YPosition = sourceBall.YPosition - sourceBall.Radius;               
            }
            if (e.PropertyName == "Radius")
            {
                this.Radius = sourceBall.Radius;
            }
        }


        public override double XPosition
        {
            get => _xPosition;
            set
            {
                _xPosition = value;
                RaisePropertyChanged();
            }
        }

        public override double YPosition
        {
            get => _yPosition;
            set
            {
                _yPosition = value;
                RaisePropertyChanged();
            }
        }

        public override double Radius 
        {
            get => _radius;
            set
            {
                _radius = value; 
                RaisePropertyChanged();
            } 
        }

        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
