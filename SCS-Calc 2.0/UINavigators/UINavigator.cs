using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace SCS_Calc_2._0.UINavigators
{
    [INotifyPropertyChanged]
    public partial class UINavigator
    {
        private UIElement? currentViewelElement;
        
        public UINavigator()
        {
            currentViewelElement = null;
        }

        public UIElement? CurrentView
        {
            get
            {
                return currentViewelElement;
            }
            set
            {
                currentViewelElement = value;
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
