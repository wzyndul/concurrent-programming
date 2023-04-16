using Logic;
using Model;
using System.Collections.ObjectModel;
using ViewModel.MVVMBase;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ModelAbstractAPI _modelAPI;
        private ObservableCollection<IModelBall> _balls;
        private string _noOfBalls = "";
        private bool _isButtonEnabled = true; // dla przycisków
        public BaseCommand StartCommand { get; set; }
        public BaseCommand StopCommand { get; set; }

        //public MainViewModel() : this(ModelAbstractAPI.CreateAPI()) { }

        public MainViewModel(ModelAbstractAPI modelAPI)
        {

            StartCommand = new BaseCommand(Start, EnableButton);
            //StopCommand = new RelayCommand(...);
            _modelAPI = modelAPI ?? ModelAbstractAPI.CreateAPI();
        }


        public void Start()
        {
            // wszystko potrzebne do startu apki uzywajac modelapi
            int noOfBalls = int.Parse(_noOfBalls);
            for(int i = 0; i < noOfBalls; i++) 
            {
                _modelAPI.CreateRandomBallLocation();
            }
            RaisePropertyChanged("Balls");
            
            //exceptions, try, cos tam
            // musimy przekazywać ilość do dodania z AddBalls w Logice
            _modelAPI.Start(noOfBalls);  // itd 

        }

        public void Stop()
        {
            // wszystko potrzebne do stopu apki uzywajac modelapi
        }

        public ObservableCollection<IModelBall> Balls
        {
            get => _balls;

            set
            {
                _balls = value;
                RaisePropertyChanged(nameof(Balls));
            }
        }

        public string NoOfBalls
        {
            get => _noOfBalls;

            set
            {
                _noOfBalls = value;
                RaisePropertyChanged();
            }
        }

        public bool IsButtonEnabled
        {
            get => _isButtonEnabled;
            set
            {
                _isButtonEnabled = value; RaisePropertyChanged();
            }
        }

        public bool IsButtonDisabled
        {
            get => !_isButtonEnabled;
        }

        private bool EnableButton()
        {
            return _isButtonEnabled;
        }

        private bool DisableButton()
        {
            return !_isButtonEnabled;
        }
    }
}