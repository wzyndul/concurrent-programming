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
        private int _xPosition { get; set; }
        private int _yPosition { get; set; }
        private int _xSpeed { get; set; }
        private int _ySpeed { get; set; }
        private int _radius { get; set; }

        internal LogicBall(int xPosition, int yPosition, int radius, int xSpeed = 0, int ySpeed = 0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _radius = radius;
        }



        // Properties needed for ModelBall
        public override int XPosition
        {
            get => _xPosition;
            set
            {
                _xPosition = value;
                RaisePropertyChanged();
            }
        }

        public override int YPosition
        {
            get => _yPosition;
            set
            {
                _yPosition = value;
                RaisePropertyChanged();
            }
        }
        public override int Radius
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

