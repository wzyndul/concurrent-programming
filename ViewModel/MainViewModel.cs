using System.Collections.ObjectModel;
using ViewModel.MVVMBase;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        // nie widzi API, dk
        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        

    }
}