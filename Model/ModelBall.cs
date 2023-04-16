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
    public class ModelBall : INotifyPropertyChanged
    {
        public int _xPosition;
        public int _yPosition;
        // bez radius nie

        public ModelBall(IBall ball)
        {
            this._xPosition = ball.GetXPosition();          // NIE JESTEM PEWNA CZY TO TAK NIESTETY nie chce mi się myśleć jest 3 w nocy - czy to ta sama zmienna jak ją wezmę getterem
            this._yPosition = ball.GetYPosition();
            ball.PropertyChanged += UpdateBall; // nullability? 
        }


        private void UpdateBall(Object source, PropertyChangedEventArgs e)
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
        }


        public int XPosition
        {
            get => _xPosition;
            set
            {
                _xPosition = value;
                RaisePropertyChanged();
            }
        }

        public int YPosition
        {
            get => _yPosition;
            set
            {
                _yPosition = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
