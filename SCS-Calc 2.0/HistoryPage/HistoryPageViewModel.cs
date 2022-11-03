using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc;
using System;
using System.Collections.ObjectModel;
using System.Windows;

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
                model.SaveToTXT(SelectedConfiguration);
            }
        }

        [RelayCommand]
        private void DeleteConfiguration()
        {
            if (SelectedConfiguration != null)
            {
                if (MessageBox.Show(
                    $"Вы действительно хотите удалить выбранную конфигурацию СКС?{Environment.NewLine}" +
                    $"({SelectedConfiguration.RecordTime.ToShortDateString()} {SelectedConfiguration.RecordTime.ToLongTimeString()}, " +
                    $"мин. - {SelectedConfiguration.MinPermanentLink:F0} м, макс. - {SelectedConfiguration.MaxPermanentLink:F0} м, всего - " +
                    $"{SelectedConfiguration.TotalСableQuantity:F0} м)",
                    "Удаление конфигурации СКС", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    model.DeleteConfiguration(SelectedConfiguration);
                }
            }
        }

        [RelayCommand]
        private void DeleteAllConfigurations()
        {
            if (Configurations.Count > 0)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить ВСЕ конфигурации СКС? ({Configurations.Count} конфигураций){Environment.NewLine}" +
                    $"Отменить это действие будет невозможно", "Удаление ВСЕХ конфигураций СКС", MessageBoxButton.YesNoCancel, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                {
                    model.DeleteAllConfigurations();
                }
            }
        }
    }
}
