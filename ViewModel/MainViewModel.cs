using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ModelAbstractAPI _modelAPI;
        private ObservableCollection<IModelBall> _balls;
        private string _noOfBalls = "";

        public Command StartCommand { get; set; }
        public Command StopCommand { get; set; }


        public MainViewModel()
        {
            StartCommand = new Command(Start);
            StopCommand = new Command(Stop);
            _modelAPI = ModelAbstractAPI.CreateAPI();
        }


        public void Start()
        {
            int noOfBalls = int.Parse(_noOfBalls);
            _modelAPI.Start(noOfBalls);
            RaisePropertyChanged(() => Balls);
        }

        public void Stop()
        {
            _modelAPI.ClearBoard();
        }

        public ObservableCollection<IModelBall> Balls
        {
            get => _modelAPI.GetBalls();
        }

        public string NoOfBalls
        {
            get => _noOfBalls;

            set
            {
                if (_noOfBalls != value)
                {
                    _noOfBalls = value;
                    RaisePropertyChanged(() => NoOfBalls);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                string propertyName = memberExpression.Member.Name;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }




    }
}