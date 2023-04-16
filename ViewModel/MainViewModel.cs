using Logic;
using Model;
using System.Collections.ObjectModel;
using ViewModel.MVVMBase;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ModelAbstractAPI _modelAPI;
        private ObservableCollection<ModelBall> _balls;
        private string _noOfBalls = "";
        private bool _isButtonEnabled = true; // dla przycisków
        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }

        public MainViewModel() : this(ModelAbstractAPI.CreateAPI()) { }

        public MainViewModel(ModelAbstractAPI modelAPI)
        {
            // StartCommand = new RelayCommand(...);
            // StopCommand = new RelayCommand(...);
            _modelAPI = modelAPI ?? ModelAbstractAPI.CreateAPI();
        }

        public void Start()
        {
            // wszystko potrzebne do startu apki uzywajac modelapi
            int noOfBalls = int.Parse(_noOfBalls);
            //exceptions, try, cos tam
            // musimy przekazywać ilość do dodania z AddBalls w Logice
            _modelAPI.Start();  // itd 
        }

        public void Stop()
        {
            // wszystko potrzebne do stopu apki uzywajac modelapi
        }

        public ObservableCollection<ModelBall> Balls
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

        private void EnableButton()
        {
            // coś tu można jeszcze co nie
            _isButtonEnabled = true;
        }

        private void DisableButton()
        {
            _isButtonEnabled = false;
        }
    }
}