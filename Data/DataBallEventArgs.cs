namespace Data
{
    public class DataBallEventArgs
    {
        public IDataBall DataBall;
        public DataBallEventArgs(IDataBall ball) {
            DataBall = ball;
        }
    }
}