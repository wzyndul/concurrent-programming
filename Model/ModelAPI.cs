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

        /*public ModelAPI(LogicAbstractAPI logicAPI)
        {
            _logicAPI = logicAPI ?? LogicAbstractAPI.CreateAPI(20, 30, 5);        // te wartości tak se o bo nie wiem co wpisać
        }

        public ModelAPI() : this(LogicAbstractAPI.CreateAPI(20, 30, 5)) { }*/

        // REDO CHYBA TAK?
        public ModelAPI()
        {
            _logicAPI = LogicAbstractAPI.CreateAPI(20, 30, 5);        // te wartości tak se o bo nie wiem co wpisać
        }


        /* The ObservableCollection<T> class is similar to the List<T> class, but with the additional feature of raising events when its contents change.
         * Specifically, it implements the INotifyCollectionChanged interface, which defines the CollectionChanged event that gets raised whenever items are added, removed, or the whole list is refreshed. */

        public override ObservableCollection<IModelBall> GetBalls()      // ????????????
        {
            _balls.Clear();
            foreach (IBall ball in _logicAPI.GetBalls())
            {               
                _balls.Add(new ModelBall(ball)); 
            }
            return _balls;
        }

        public override void ClearBoard()
        {
            _logicAPI.ClearBoard();
        }

        public override void CreateRandomBallLocation() // moge dac voida zamiast IBalla? xd
        {
            _logicAPI.CreateRandomBallLocation(); 
        }

        public override void Start(int number)    // CO TU DAĆ, NIE WIEM XD może coś innego
        {
            _logicAPI.AddBalls(number);          
            _logicAPI.MoveBalls();
        }

        public override void Stop()     //  idk czy to potrzbene
        {
            throw new NotImplementedException();
        }

        // no te metody to struggle

    }

}
