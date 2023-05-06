using Logic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateAPI(LogicAbstractAPI logicAbstractAPI = default)
        {
            return new ModelAPI(logicAbstractAPI ?? LogicAbstractAPI.CreateAPI(585, 430, 10.0));
        }

        public abstract ObservableCollection<IModelBall> GetBalls();
        public abstract void ClearBoard();
        public abstract void Start(int number);
        
    }
}