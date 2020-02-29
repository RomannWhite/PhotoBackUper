using System.ComponentModel;

namespace PhotoBackUper.VM
{
    class ViewModel : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
