using System.ComponentModel;

namespace TreeView
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged  = (sender, e) => {};
    }
}
