namespace Logic
{
    public class LogicBallEventArgs
    {
        public ILogicBall LogicBall;
        public LogicBallEventArgs(ILogicBall ball)
        {
            LogicBall = ball;
        }
    }
}