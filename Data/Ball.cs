namespace Data
{
    public class Ball // czy działać na liczbach zmiennoprzecinkowych czy nie
    {
        public double XPosition{ get; set; }
        public double YPosition { get; set; }
        public double Radius { get; } // to będzie stała wartość bez możliwości zmiany
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }

        public Ball(double xPosition, double yPosition, double xSpeed, double ySpeed)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.XSpeed = xSpeed;
            this.YSpeed = ySpeed;
            this.Radius = 5.0; // jakaś wartość stała dla wszystkich hednakwoa
        }
    }
}