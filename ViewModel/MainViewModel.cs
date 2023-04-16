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
            int noOfBalls = int.Parse(_noOfBalls);
            _modelAPI.Start(noOfBalls);
            RaisePropertyChanged(nameof(Balls));
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
                _noOfBalls = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}