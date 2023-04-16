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
        private int _xPosition { get; set; }
        private int _yPosition { get; set; }
        private int _radius { get; set; }

        public ModelBall(int xPos, int yPos, int radius)
        {
            this._xPosition = xPos;          // NIE JESTEM PEWNA CZY TO TAK NIESTETY nie chce mi się myśleć jest 3 w nocy - czy to ta sama zmienna jak ją wezmę getterem
            this._yPosition = yPos;
            this._radius = radius;
        }


        public override void UpdateBall(Object source, PropertyChangedEventArgs e) // to musi byc public teraz
        {
            IBall sourceBall = (IBall)source;
            if (e.PropertyName == "XPosition")
            {
                this.XPosition = sourceBall.XPosition - sourceBall.Radius;   // the center of the ball will be aligned with the coordinates of the position property        
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
    }
}
