namespace Meteo.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        public T Model { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return;
            storage = value;
            RaisePropertyChanged(propertyName);
        }
        #endregion
    }
}
