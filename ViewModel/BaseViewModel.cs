namespace Meteo.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class BaseViewModel<TViewModel> : INotifyPropertyChanged
    {
        public TViewModel Model { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<TProperty>(ref TProperty storage, TProperty value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<TProperty>.Default.Equals(storage, value))
                return;
            storage = value;
            RaisePropertyChanged(propertyName);
        }
        #endregion
    }
}
