using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{
    public abstract class IModelBall
    {
        public abstract void UpdateBall(Object source, PropertyChangedEventArgs e);
        public static IModelBall CreateModelBall(int xPos, int yPos, int Radius)
        { 
            return new ModelBall(xPos, yPos, Radius); 
        }
        
        // Properties needed for ModelBall
        public abstract int XPosition { get; set; }
        public abstract int YPosition { get; set; }
        public abstract int Radius { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

    }
}
