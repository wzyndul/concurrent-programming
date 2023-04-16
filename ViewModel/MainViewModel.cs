using Logic;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.MVVMBase;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ModelAbstractAPI _modelAPI;
        private ObservableCollection<IModelBall> _balls;
        private string _noOfBalls = "";
        //private bool _isButtonEnabled = true; // dla przycisków
        public BaseCommand StartCommand { get; set; }
        public BaseCommand StopCommand { get; set; }

     

        public MainViewModel()
        {

            StartCommand = new BaseCommand(Start);
            StopCommand = new BaseCommand(Stop);
            _modelAPI = ModelAbstractAPI.CreateAPI();
        }


        public void Start()
        {
            // wszystko potrzebne do startu apki uzywajac modelapi
            int noOfBalls = int.Parse(_noOfBalls);
            //for(int i = 0; i < noOfBalls; i++) 
            //{
            //    _modelAPI.CreateRandomBallLocation();
            //}
            //_balls = _modelAPI.GetBalls();
            _modelAPI.Start(noOfBalls);
            RaisePropertyChanged(nameof(Balls));
            
            //exceptions, try, cos tam
            // musimy przekazywać ilość do dodania z AddBalls w Logice
              // itd 

        }

        public void Stop()
        {
            // wszystko potrzebne do stopu apki uzywajac modelapi
        }

        public ObservableCollection<IModelBall> Balls
        {
            get => _modelAPI.GetBalls();

            set
            {
                _balls = value;
                //RaisePropertyChanged("Balls");
            }
        }

        public string NoOfBalls
        {
            get => _noOfBalls;

            set
            {
                _noOfBalls = value;
                RaisePropertyChanged(nameof(NoOfBalls));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}