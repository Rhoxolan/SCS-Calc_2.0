using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    [INotifyPropertyChanged]
    public partial class HistoryPageViewModel
    {
        private readonly ApplicationModel model;
        private Configuration? selectedConfiguration;

        public HistoryPageViewModel(ApplicationModel model)
        {
            this.model = model;
        }

        public ReadOnlyObservableCollection<Configuration> Configurations
        {
            get => model.Configurations;
        }

        public Configuration? SelectedConfiguration
        {
            get
            {
                return selectedConfiguration;
            }
            set
            {
                selectedConfiguration = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        private void SaveToTXT()
        {
            if (SelectedConfiguration != null)
            {
                SelectedConfiguration.SaveToTXT();
            }
        }
    }
}
