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
        public int _xPosition;
        public int _yPosition;
        public int _radius;

        public ModelBall(IBall ball)
        {
            this._xPosition = ball.GetXPosition();          // NIE JESTEM PEWNA CZY TO TAK NIESTETY nie chce mi się myśleć jest 3 w nocy - czy to ta sama zmienna jak ją wezmę getterem
            this._yPosition = ball.GetYPosition();
            this._radius = ball.GetRadius();
            ball.PropertyChanged += UpdateBall; // nullability? 
        }


        public override void UpdateBall(Object source, PropertyChangedEventArgs e) // to musi byc public teraz
        {
            IBall sourceBall = (IBall)source;
            if (e.PropertyName == "XPosition")
            {
                this._xPosition = sourceBall.GetXPosition() - sourceBall.GetRadius();   // the center of the ball will be aligned with the coordinates of the position property
                //_xPosition = sourceBall.GetXPosition();
            }
            if (e.PropertyName == "YPosition")
            {
                this._yPosition = sourceBall.GetYPosition() - sourceBall.GetRadius();
                _yPosition = sourceBall.GetYPosition();
            }
            if (e.PropertyName == "Radius")
            {
                this._radius = sourceBall.GetRadius();
                _radius = sourceBall.GetRadius();
            }
        }


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
                _radius = value; RaisePropertyChanged();
            } 
        }

        public override event PropertyChangedEventHandler? PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
