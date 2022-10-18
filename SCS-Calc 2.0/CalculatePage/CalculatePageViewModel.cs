using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc;
using System;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    [INotifyPropertyChanged]
    public partial class CalculatePageViewModel
    {
        private readonly ApplicationModel model;

        public ObservableCollection<Configuration> Configurations { get; }

        public CalculatePageViewModel(ApplicationModel model)
        {
            this.model = model;
            Configurations = new(model.Configurations);
        }

        public double MinPermanentLink { get; set; } = 1;

        public double MaxPermanentLink { get; set; } = 1;

        public int NumberOfWorkplaces { get; set; } = 1;

        public int NumberOfPorts { get; set; } = 1;

        public double? CableHankMeterage { get; set; } = 305;

        [RelayCommand]
        private void AddConfiguration() => model.AddConfiguration(MinPermanentLink, MaxPermanentLink, NumberOfWorkplaces, NumberOfPorts, CableHankMeterage);

        [RelayCommand]
        private void SetCableHankMeterage(string value)
        {
            CableHankMeterage = Convert.ToDouble(value);
            OnPropertyChanged(nameof(CableHankMeterage));
        }
    }
}
