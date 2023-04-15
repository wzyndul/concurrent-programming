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
        private LogicAbstractAPI _logic;
        // COŚ TU JESZCZE?
        public ModelAPI(LogicAbstractAPI logic)
        {
            _logic = logic ?? LogicAbstractAPI.CreateAPI(20, 30, 5);        // te wartości tak se o bo nie wiem co wpisać
        }

        public ModelAPI() : this(LogicAbstractAPI.CreateAPI(20, 30, 5)) { }

        // METODY DO ZROBIENIA

        public override ObservableCollection<IBall> CreateBall()
        {
            throw new NotImplementedException();
        }

        public override void ClearBoard()
        {
            throw new NotImplementedException();
        }

        public override IBall CreateRandomBallLocation()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }

}
