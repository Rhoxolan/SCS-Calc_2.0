using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace SCSCalc_2_0.UINavigators
{
    [INotifyPropertyChanged]
    public partial class UINavigator
    {
        private UIElement? currentViewElement;
        
        public UINavigator()
        {
            currentViewElement = null;
        }

        public UIElement? CurrentView
        {
            get
            {
                return currentViewElement;
            }
            set
            {
                currentViewElement = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        private void SetCurrentView(UIElement element)
        {
            CurrentView = element;
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
