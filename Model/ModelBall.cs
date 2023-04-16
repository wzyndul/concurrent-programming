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
    internal class ModelBall : INotifyPropertyChanged
    {
        private int _xPosition;
        private int _yPosition;
        // bez radius nie

        public ModelBall(IBall ball)
        {
            this._xPosition = ball.GetXPosition();          // bo sam IBall nie ma tych properties
            this._yPosition = ball.GetYPosition();
            ball.PropertyChanged += UpdateBall; // nullability? hę? xd
        }

        private void UpdateBall(Object source, PropertyChangedEventArgs e)
        {
            IBall sourceBall = (IBall)source;
            if (e.PropertyName == "XPosition")
            {
                this._xPosition = sourceBall.GetXPosition() - sourceBall.GetRadius();   // the center of the ball will be aligned with the coordinates of the position property
            }
            if (e.PropertyName == "YPosition")
            {
                this._yPosition = sourceBall.GetYPosition() - sourceBall.GetRadius();
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
