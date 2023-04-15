using Logic;
using Model;
using System.Collections.ObjectModel;
using ViewModel.MVVMBase;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ModelAbstractAPI _model;
        private ObservableCollection<IBall> _balls;
        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        
        public MainViewModel() : this(ModelAbstractAPI.CreateAPI()) { }

        public MainViewModel(ModelAbstractAPI model)
        {
            // StartCommand = new RelayCommand(...);
            // StopCommand = new RelayCommand(...);
            _model = model;
        }

        public ObservableCollection<IBall> Balls
        {
            get => _balls;

            set
            {
                _balls = value;
                RaisePropertyChanged(nameof(Balls));
            }
        }
    }
}