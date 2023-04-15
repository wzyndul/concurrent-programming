using Logic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateAPI()
        {
            return new ModelAPI();
        }

        public abstract ObservableCollection<IBall> CreateBall();
        public abstract IBall CreateRandomBallLocation();
        public abstract void ClearBoard();
        public abstract void Start();
        public abstract void Stop();

        // DO ZROBIENIA METODY
    }
}