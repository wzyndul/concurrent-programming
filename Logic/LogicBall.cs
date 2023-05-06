using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        private double _xSpeed { get; set; }
        private double _ySpeed { get; set; }
        private double _radius { get; set; }
        private int _weight { get; set; }

        internal LogicBall(double xPosition, double yPosition, double radius, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _radius = radius;
            _weight = weight;
        }



        // Properties needed for ModelBall
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

        public override void UpdateBall(object source, PropertyChangedEventArgs e)
        {
            IDataBall sourceBall = (IDataBall)source;
            GetType().GetProperty(e.PropertyName!)!.SetValue(
                this, sourceBall.GetType().GetProperty(e.PropertyName!)!.GetValue(sourceBall)
            );
        }
    }
}

