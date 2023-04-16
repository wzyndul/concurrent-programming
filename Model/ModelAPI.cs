using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelAPI : ModelAbstractAPI
    {
        private LogicAbstractAPI _logicAPI;
        private ObservableCollection<IModelBall> _balls = new ObservableCollection<IModelBall>();

        public ModelAPI()
        {
            _logicAPI = LogicAbstractAPI.CreateAPI(800, 700, 10);       
        }


        public override ObservableCollection<IModelBall> GetBalls()   
        {
            _balls.Clear();
            foreach (IBall ball in _logicAPI.GetBalls())
            {
                IModelBall modelBall = IModelBall.CreateModelBall(ball.XPosition, ball.YPosition, ball.Radius);
                _balls.Add(modelBall);
                ball.PropertyChanged += modelBall.UpdateBall!;
            }
            return _balls;
        }

        public override void ClearBoard()
        {
            _logicAPI.ClearBoard();
        }

        public override void CreateRandomBallLocation() 
        {
            _logicAPI.CreateRandomBallLocation(); 
        }

        public override void Start(int number)    
        {
            _logicAPI.ClearBoard();
            _logicAPI.AddBalls(number);          
            _logicAPI.MoveBalls();
        }



    }

}
